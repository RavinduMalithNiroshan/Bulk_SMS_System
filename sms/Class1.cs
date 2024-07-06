using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace sms
{
    internal class Class1
    {
        static readonly string server = "127.0.0.1";
        static readonly string user = "root";
        static readonly string password = "";
        static readonly string database = "sms";
        public static string connection_string = "server='" + server + "'; user='" + user + "';database='" + database + "';password='" + password + "'";

        public MySqlConnection mysqlconnection = new MySqlConnection(connection_string);

        

        public bool connect_db()
        {
            try
            {
                mysqlconnection.Open();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool close_db()
        {
            try
            {
                mysqlconnection.Close();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

       /* public void searchdata( String serch)
        {

            String con_string = "server=127.0.0.1;user=root;password=;database=sms";
            MySqlConnection con= new MySqlConnection(con_string);
            String query = "select name,mobile,birthday where mobile='" + Mobile + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr = cmd.ExecuteReader();*/

            
        
    }


}
