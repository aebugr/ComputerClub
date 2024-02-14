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

namespace ComputerClubBugrina.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainComputerClub.xaml
    /// </summary>
    public partial class MainComputerClub : Page
    {
        private ClubData clubData;
        public static MainComputerClub cc;
        public MainComputerClub()
        {
            InitializeComponent();
            cc = this;
            clubData = new ClubData();
            LoadClubData();
            DataContext = this;
        }
        public void LoadClubData()
        {
            DataTable dataTable = clubData.GetClubData();
            CCListView.ItemsSource = dataTable.DefaultView;
        }
        private void AddClubClick(object sender, RoutedEventArgs e)
        {
            Models.ComputerClub newClub = new Models.ComputerClub();
            NavigationService.Navigate(new Pages.Add.AddComputerClub(newClub));
        }

        private void UpdateClubClick(object sender, RoutedEventArgs e)
        {
            if (CCListView.SelectedItem != null)
            {
                DataRowView row = (DataRowView)CCListView.SelectedItem;
                int clubId = Convert.ToInt32(row["id"]);

                Models.ComputerClub selectedClub = new Models.ComputerClub
                {
                    Id = clubId,
                    Name = row["name"].ToString(),
                    Address = row["address"].ToString(),
                    WorkTime = row["worktime"].ToString()
                };
                NavigationService.Navigate(new Pages.Add.AddComputerClub(selectedClub));
            }
        }

        private void DeleteClubClick(object sender, RoutedEventArgs e)
        {
            if (CCListView.SelectedItem != null)
            {
                DataRowView row = (DataRowView)CCListView.SelectedItem;
                int clubId = Convert.ToInt32(row["id"]);

                clubData.DeleteClub(clubId);

                LoadClubData();
            }
        }

        private void SortClubClick(object sender, RoutedEventArgs e)
        {
            //MainWindow.init.OpenPages(new Pages.Sort());
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }

        private void GoRentalClick(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Main.MainComputerRental());
        }
    }
}
