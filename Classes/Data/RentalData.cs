using ComputerClubBugrina.Classes.Common;
using ComputerClubBugrina.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClubBugrina.Classes.Data
{
    public class RentalData
    {
        private Connection connection;
        public RentalData()
        {
            connection = new Connection();
        }
        public DataTable GetRentalData()
        {
            string query = "SELECT id, fioclient, reservationdatetime FROM rental";
            return connection.GetDataFromDatabase(query);
        }
        public void AddRental(ComputerRental compRental)
        {
            string formattedDateTime = compRental.ReservationDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"INSERT INTO rental (fioclient, reservationdatetime) " +
                           $"VALUES ('{compRental.FioClient}', '{formattedDateTime}')";
            connection.ExecuteQuery(query);
        }

        public void UpdateRental(ComputerRental compRental)
        {
            string formattedDateTime = compRental.ReservationDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"UPDATE rental SET fioclient = '{compRental.FioClient}', " +
                           $"reservationdatetime = '{formattedDateTime}' " +
                           $"WHERE id = {compRental.Id}";
            connection.ExecuteQuery(query);
        }

        public void DeleteRental(int rentalId)
        {
            string deleteRentalQuery = $"DELETE FROM rental WHERE id = {rentalId}";
            connection.ExecuteQuery(deleteRentalQuery);
        }
    }
}
