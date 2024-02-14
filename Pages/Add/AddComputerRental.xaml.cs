using ComputerClubBugrina.Classes.Data;
using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace ComputerClubBugrina.Pages.Add
{
    /// <summary>
    /// Логика взаимодействия для AddComputerRental.xaml
    /// </summary>
    public partial class AddComputerRental : Page
    {
        private RentalData rentalData;
        private Models.ComputerRental rentalToUpdate;
        public AddComputerRental(Models.ComputerRental rental = null)
        {
            InitializeComponent();
            rentalData = new RentalData();
            if (rental != null && rental.Id != 0)
            {
                rentalToUpdate = rental;
                fioclient.Text = rentalToUpdate.FioClient;
                reservationdatetime.Text = rentalToUpdate.ReservationDateTime.ToString();
                addBtn.Content = "Изменить";
                addLbl.Content = "Изменение аренды игровых комп-ов";
            }
            else
            {
                rentalToUpdate = new Models.ComputerRental();
            }
        }

        private void InsertClick(object sender, RoutedEventArgs e)
        {
            if (fioclient.Text.Length == 0)
            {
                MessageBox.Show("Поле с ФИО клиента пустое");
                return;
            }
            if (reservationdatetime.Text.Length == 0)
            {
                MessageBox.Show("Поле с датой и временем аренды пустое");
                return;
            }
            if (!Regex.IsMatch(fioclient.Text, @"^[a-zA-Zа-яА-Я]+$"))
            {
                MessageBox.Show("Проверьте введёное наименование на корректность. \n Допускаются только буквы.");
                return;
            }
            if (!Regex.IsMatch(reservationdatetime.Text, @"^[а-яА-Я0-9\s]+$"))
            {
                MessageBox.Show("Проверьте введённый адрес на корректность. \n Допускаются только буквы и цифры.");
                return;
            }
            if (rentalToUpdate.Id != 0)
            {
                rentalToUpdate.FioClient = fioclient.Text;
                rentalToUpdate.ReservationDateTime = Convert.ToDateTime(reservationdatetime.Text);

                rentalData.UpdateRental(rentalToUpdate);
            }
            else
            {
                Models.ComputerRental newRental = new Models.ComputerRental
                {
                    FioClient = fioclient.Text,
                    ReservationDateTime = Convert.ToDateTime(reservationdatetime.Text)
                };

                rentalData.AddRental(newRental);
            }
            Pages.Main.MainComputerRental.cr.LoadRentalData();
            NavigationService.GoBack();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
