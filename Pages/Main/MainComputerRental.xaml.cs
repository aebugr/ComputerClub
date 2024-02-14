using ComputerClubBugrina.Classes.Data;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ComputerClubBugrina.Pages.Main
{
    /// <summary>
    /// Логика взаимодействия для MainComputerRental.xaml
    /// </summary>
    public partial class MainComputerRental : Page
    {
        private RentalData rentalData;
        public static MainComputerRental cr;
        public MainComputerRental()
        {
            InitializeComponent();
            cr = this;
            rentalData = new RentalData();
            LoadRentalData();
            DataContext = this;
        }
        public void LoadRentalData()
        {
            DataTable dataTable = rentalData.GetRentalData();
            CRListView.ItemsSource = dataTable.DefaultView;
        }
        private void AddRentalClick(object sender, RoutedEventArgs e)
        {
            Models.ComputerRental newRental = new Models.ComputerRental();
            NavigationService.Navigate(new Pages.Add.AddComputerRental(newRental));
        }

        private void UpdateRentalClick(object sender, RoutedEventArgs e)
        {
            if (CRListView.SelectedItem != null)
            {
                DataRowView row = (DataRowView)CRListView.SelectedItem;
                int rentalId = Convert.ToInt32(row["id"]);

                Models.ComputerRental selectedRental = new Models.ComputerRental
                {
                    Id = rentalId,
                    FioClient = row["fioclient"].ToString(),
                    ReservationDateTime = Convert.ToDateTime(row["reservationdatetime"])
                };
                NavigationService.Navigate(new Pages.Add.AddComputerRental(selectedRental));
            }
        }

        private void DeleteRentalClick(object sender, RoutedEventArgs e)
        {
            if (CRListView.SelectedItem != null)
            {
                DataRowView row = (DataRowView)CRListView.SelectedItem;
                int rentalId = Convert.ToInt32(row["id"]);

                rentalData.DeleteRental(rentalId);

                LoadRentalData();
            }
        }

        private void SortRentalClick(object sender, RoutedEventArgs e)
        {
            //MainWindow.init.OpenPages(new Pages.Sort());
        }

        private void GoClubClick(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.MainComputerClub());
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }
    }
}
