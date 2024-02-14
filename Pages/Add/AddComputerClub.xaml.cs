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

namespace ComputerClubBugrina.Pages.Add
{
    /// <summary>
    /// Логика взаимодействия для AddComputerClub.xaml
    /// </summary>
    public partial class AddComputerClub : Page
    {
        private ClubData clubData;
        private Models.ComputerClub clubToUpdate;
        public AddComputerClub(Models.ComputerClub club = null)
        {
            InitializeComponent();
            clubData = new ClubData();
            if (club != null && club.Id != 0)
            {
                clubToUpdate = club;
                name.Text = clubToUpdate.Name;
                address.Text = clubToUpdate.Address;
                worktime.Text = clubToUpdate.WorkTime; 
                addBtn.Content = "Изменить";
                addLbl.Content = "Изменение компьютерного клуба";
            }
            else
            {
                clubToUpdate = new Models.ComputerClub();
            }
        }

        private void InsertClick(object sender, RoutedEventArgs e)
        {
            if (name.Text.Length == 0)
            {
                MessageBox.Show("Поле с наименованием пустое");
                return;
            }
            if (address.Text.Length == 0)
            {
                MessageBox.Show("Поле с адресом пустое");
                return;
            }
            if (worktime.Text.Length == 0)
            {
                MessageBox.Show("Поле с временем работы пустое");
                return;
            }
            if (!Regex.IsMatch(name.Text, @"^[a-zA-Zа-яА-Я]+$"))
            {
                MessageBox.Show("Проверьте введёное наименование на корректность. \n Допускаются только буквы.");
                return;
            }
            if (!Regex.IsMatch(address.Text, @"^[а-яА-Я0-9\s]+$"))
            {
                MessageBox.Show("Проверьте введённый адрес на корректность. \n Допускаются только буквы и цифры.");
                return;
            }
            if (!Regex.IsMatch(worktime.Text, @"^([01]?[0-9]|2[0-3]):[0-5][0-9] - ([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
            {
                MessageBox.Show("Проверьте введённое время работы на корректность. \n Формат должен быть HH:MM - HH:MM.");
                return;
            }
            if (clubToUpdate.Id != 0)
            {
                clubToUpdate.Name = name.Text;
                clubToUpdate.Address = address.Text;
                clubToUpdate.WorkTime = worktime.Text;

                clubData.UpdateClub(clubToUpdate);
            }
            else
            {
                Models.ComputerClub newClub = new Models.ComputerClub
                {
                    Name = name.Text,
                    Address = address.Text,
                    WorkTime = worktime.Text
                };

                clubData.AddClub(newClub);
            }
            Pages.MainComputerClub.cc.LoadClubData();
            NavigationService.GoBack();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
