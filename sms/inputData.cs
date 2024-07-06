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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace sms
{
    public partial class inputData : UserControl
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password= ");
        public inputData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String insertQuery = "INSERT INTO sms.data(name,mobile,birthday) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";

            con.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, con);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data inserted");
                }
                else
                {
                    MessageBox.Show("Data not insert");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

            con.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
