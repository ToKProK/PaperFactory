using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaperFactory.DB
{
    internal class DBConnection
    {
        static string DBConnect = "server=localhost; user=root; password=13241324; database=yp";
        static public MySqlDataAdapter MySqlDataAdapter;
        static MySqlConnection Connection;
        static public MySqlCommand MsCommand;


        public static bool ConnectorDB()
        {
            try
            {
                Connection = new MySqlConnection(DBConnect);
                Connection.Open();
                MsCommand = new MySqlCommand();
                MsCommand.Connection = Connection; 
                MySqlDataAdapter = new MySqlDataAdapter();
                return true;
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к серверу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public static void Close_Open()
        {
            Connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return Connection;
        }
    }
}
