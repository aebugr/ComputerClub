using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClubBugrina.Classes
{
    public class CompClubContext : Models.ComputerClub
    {
        public CompClubContext(int Id, string Name, string Address, DateTime WorkTime) 
            : base(Id, Name, Address, WorkTime)
        { }
        public static List<CompClubContext> AllCC()
        {
            List<CompClubContext> list = new List<CompClubContext>();
            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlDataReader query = Common.Connection.Query("SELECT * FROM compclub.clubs", connection);
            while (query.Read())
            {
                list.Add(new CompClubContext(
                    query.GetInt32(0),
                    query.GetString(1),
                    query.GetString(2),
                    query.GetDateTime(3)));
            }
            connection.Close();
            MySqlConnection.ClearPool(connection);
            return list;
        }
    }
}
