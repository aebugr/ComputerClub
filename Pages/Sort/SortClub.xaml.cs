using ComputerClubBugrina.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для SortClub.xaml
    /// </summary>
    public partial class SortClub : Page
    {
        public SortClub()
        {
            InitializeComponent();
        }

        private void SortClick(object sender, RoutedEventArgs e)
        {
            string filter = sortClub.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Поле с фильтром пустое");
                return;
            }
            if (!Regex.IsMatch(filter, @"^([01]?[0-9]|2[0-3]):[0-5][0-9] - ([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
            {
                MessageBox.Show("Проверьте введенный формат времени. \n Формат должен быть HH:MM - HH:MM.");
                return;
            }

            string[] times = filter.Split('-');
            string startTime = times[0].Trim();
            string endTime = times[1].Trim();
            List<Models.ComputerClub> filteredClubs = new List<Models.ComputerClub>();
            foreach (Models.ComputerClub club in CompClubContext.AllCC())
            {
                string[] clubTimes = club.WorkTime.Split('-');
                string clubStartTime = clubTimes[0].Trim();
                string clubEndTime = clubTimes[1].Trim();
                if (TimeSpan.Parse(clubStartTime) >= TimeSpan.Parse(startTime) &&
                    TimeSpan.Parse(clubEndTime) <= TimeSpan.Parse(endTime))
                {
                    filteredClubs.Add(club);
                }
            }
            if (filteredClubs.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Models.ComputerClub club in filteredClubs)
                {
                    sb.AppendLine($"Название: {club.Name}, Адрес: {club.Address}, Время работы: {club.WorkTime}");
                }
                sortLbl.Content = sb.ToString();
            }
            else
            {
                MessageBox.Show("Ничего не найдено по заданному фильтру.");
                sortLbl.Content = string.Empty;
            }
        }
        private void TimeFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            sortLbl.Content = string.Empty;
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
