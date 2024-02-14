using ComputerClubBugrina.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerClubBugrina.Pages.Sort
{
    /// <summary>
    /// Логика взаимодействия для SortRental.xaml
    /// </summary>
    public partial class SortRental : Page
    {
        public SortRental()
        {
            InitializeComponent();
        }
        private void SortClick(object sender, RoutedEventArgs e)
        {
            string filter = sortRental.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Поле с фильтром пустое");
                return;
            }
            if (!DateTime.TryParseExact(filter, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime))
            {
                MessageBox.Show("Проверьте введенный формат времени. Формат должен быть yyyy-MM-dd hh:mm:ss");
                return;
            }
            List<Models.ComputerRental> filteredRentals = new List<Models.ComputerRental>();
            foreach (Models.ComputerRental rental in CompRentContext.AllCR())
            {
                string rentalTime = rental.ReservationDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (DateTime.ParseExact(rentalTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) == startTime)
                {
                    filteredRentals.Add(rental);
                }
            }
            if (filteredRentals.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Models.ComputerRental rental in filteredRentals)
                {
                    sb.AppendLine($"ФИО клиента: {rental.FioClient}, Дата и время аренды: {rental.ReservationDateTime}");
                }
                sortLbl.Content = sb.ToString();
            }
            else
            {
                MessageBox.Show("Ничего не найдено по заданному фильтру.");
                sortLbl.Content = string.Empty;
            }
        }
        private void SortRental_TextChanged(object sender, TextChangedEventArgs e)
        {
            sortLbl.Content = string.Empty;
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
