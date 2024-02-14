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
    public class ClubData
    {
        private Connection connection;
        public ClubData()
        {
            connection = new Connection();
        }
        public DataTable GetClubData()
        {
            string query = "SELECT id, name, address, worktime FROM clubs";
            return connection.GetDataFromDatabase(query);
        }
        public void AddClub(ComputerClub compClub)
        {
            string query = $"INSERT INTO clubs (name, address, worktime) " +
                $"VALUES ('{compClub.Name}'," +
                $" ' {compClub.Address} ', " +
                $" ' {compClub.WorkTime} ' )";
            connection.ExecuteQuery(query);
        }
        public void UpdateClub(ComputerClub compClub)
        {
            string query = $"UPDATE clubs SET name = '{compClub.Name}'," +
                $" address = '{compClub.Address}'," +
                $" worktime = '{compClub.WorkTime}' " +
                $"WHERE id = {compClub.Id}";
            connection.ExecuteQuery(query);
        }
        public void DeleteClub(int clubId)
        {
            string deleteClubQuery = $"DELETE FROM clubs WHERE id = {clubId}";
            connection.ExecuteQuery(deleteClubQuery);
        }
    }
}
