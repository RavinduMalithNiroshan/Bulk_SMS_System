using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection;
using System.IO.Ports;
using System.Data.SqlClient;

namespace sms
{
    public partial class Contact_info : UserControl
    {

        public string Mobile { get; private set; }
        public Contact_info()
        {
            InitializeComponent();
        }

        private void Contact_info_Load(object sender, EventArgs e)
        {        
            loadData();
        }

        public void loadData()
        {
            var database = new Class1();
            if (database.connect_db())
            {
                String query = "SELECT name, mobile, birthday FROM data ";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.mysqlconnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingsoure = new BindingSource();
                bindingsoure.DataSource = dt;


                dataGridView1.DataSource = bindingsoure;
                database.close_db();

            }
            else
            {
                MessageBox.Show("database error");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /* Class1 cls = new Class1();
             cls.searchdata(textBox1.Text);
             textBox2.Text=cls.Mobile.ToString();*/


             var database_1 = new Class1();
             if (database_1.connect_db())
             {
                MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password= ");
                

        Class1 class1 = new Class1();
                class1.mysqlconnection = database_1.mysqlconnection;
                MySqlCommand mySqlCommand = new MySqlCommand("Select name, birthday, mobile from data where name=@name", con);
            

                

                mySqlCommand.Parameters.AddWithValue("@name", textBox1.Text);
                MySqlDataReader reader1;
                reader1 = mySqlCommand.ExecuteReader();
                if (reader1.Read())
                {
                   /* textBox2.Text = reader1["birtday"].ToString();
                    textBox3.Text = reader1["mobile"].ToString();*/
                }
                else
                {
                    MessageBox.Show("no data found");
                }
                 database_1.close_db();

             }
             else
             {
                 MessageBox.Show("database error");
             }

         
            /*MySqlCommand cmd = new MySqlCommand("Select name, birthday, mobile from data where name=@name", con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                textBox2.Text = reader["birtday"].ToString();
                textBox3.Text = reader["mobile"].ToString();
            }
            else
            {
                MessageBox.Show("no data found");
            }
            con.Close();*/


        }
        

        private void button2_Click(object sender, EventArgs e)
        {

            var database = new Class1();
            if (database.connect_db())
            {
                String query = "DELETE FROM data where mobile='" + textBox1.Text + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.mysqlconnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingsoure = new BindingSource();
                bindingsoure.DataSource = dt;

                MessageBox.Show("Deleted successfull");
            }
            else
            {
                MessageBox.Show("canot delete");
            }

            loadData();
            textBox1.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadData();
            textBox1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
