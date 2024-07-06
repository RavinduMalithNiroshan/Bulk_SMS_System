using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sms
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check username and password

              if(textBox1.Text == "admin" && textBox2.Text == "admin") 
              {
                  Home mainhome = new Home();
                  mainhome.Show();
                  this.Hide();
              }
              else
              {
                  MessageBox.Show("Recheck your username or password");
              }

              //show home page and hide login page
          
            this.Hide();

        }
    }
}
