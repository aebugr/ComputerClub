using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ComputerClubBugrina.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AdminClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainComputerClub());
        }

        private void EmployeesClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Main.MainComputerRental());
        }
    }
}
