using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerClubBugrina.Classes.Common
{
    public class Connection
    {
        public static readonly string connect = "server=127.0.0.1;port=3306;database=compclub;user=root;pwd={_DDc9HV;SslMode=none;";
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
        public DataTable GetDataFromDatabase(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connect))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message);
            }
            return dataTable;
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connect))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MessageBox.Show("Executing query: " + query); 
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message);
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
