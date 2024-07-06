using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Net;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace sms
{
    public partial class send_message : UserControl
    {

        public send_message()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            msg();
            textBox1.Clear();
            richTextBox1.Clear();
        }


        private void msg()
        {
            // This URL is used for sending messages
            string myURI = "https://api.bulksms.com/v1/messages";

            // change these values to match your own account
            string myUsername = "Enter your username";
            string myPassword = "Enter your password";

            // the details of the message we want to send
            string myData = "{to: '" + textBox1.Text + "', body:'" + richTextBox1.Text + "'}";

            // build the request based on the supplied settings
            var request = WebRequest.Create(myURI);

            // supply the credentials
            request.Credentials = new NetworkCredential(myUsername, myPassword);
            request.PreAuthenticate = true;
            // we want to use HTTP POST
            request.Method = "POST";
            // for this API, the type must always be JSON
            request.ContentType = "application/json";

            // Here we use Unicode encoding, but ASCIIEncoding would also work
            var encoding = new UnicodeEncoding();
            var encodedData = encoding.GetBytes(myData);

            // Write the data to the request stream
            var stream = request.GetRequestStream();
            stream.Write(encodedData, 0, encodedData.Length);
            stream.Close();

            // try ... catch to handle errors nicely
            try
            {
                // make the call to the API
                var response = request.GetResponse();

                // read the response and print it to the console
                var reader = new StreamReader(response.GetResponseStream());
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (WebException ex)
            {
                // show the general message
                Console.WriteLine("An error occurred:" + ex.Message);

                // print the detail that comes with the error
                var reader = new StreamReader(ex.Response.GetResponseStream());
                Console.WriteLine("Error details:" + reader.ReadToEnd());
            }
            MessageBox.Show("Message Send Successfull");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            String date = DateTime.Now.ToShortDateString();
            textBox1.Text = date;
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password= ");
            MySqlCommand cmd = new MySqlCommand("SELECT birthday FROM data (@birthday)",con);
            cmd.Parameters.AddWithValue("@birthday", (textBox1.Text));

            String date_1 = date;
            

            if (date == date_1)
            {
                MessageBox.Show("equle cuddah");
            }

            else
            {
                MessageBox.Show("error");
            }*/

        }
    }
}

    



