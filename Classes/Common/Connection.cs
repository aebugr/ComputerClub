using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerClubBugrina.Classes.Common
{
    public class Connection
    {
        public static readonly string connect = "server=127.0.0.1;port=3306;database=compclub;user=root;pwd=;SslMode=none;";
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(connect);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
                return null;
            }
        }

        public static MySqlDataReader Query(string Sql, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(Sql, connection);
            return command.ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
