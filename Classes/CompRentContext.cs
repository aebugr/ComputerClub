using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClubBugrina.Classes
{
    public class CompRentContext : Models.ComputerRental
    {
        public CompRentContext(int Id, string FioClient, DateTime ReservationDateTime)
           : base(Id, FioClient, ReservationDateTime)
        { }
        public static List<CompRentContext> AllCR()
        {
            List<CompRentContext> list = new List<CompRentContext>();
            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlDataReader query = Common.Connection.Query("SELECT * FROM compclub.rental", connection);
            while (query.Read())
            {
                list.Add(new CompRentContext(
                    query.GetInt32(0),
                    query.GetString(1),
                    query.GetDateTime(2)));
            }
            connection.Close();
            MySqlConnection.ClearPool(connection);
            return list;
        }
    }
}
