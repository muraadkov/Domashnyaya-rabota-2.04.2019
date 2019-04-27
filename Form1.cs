using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLAutentification2._04._2019
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder SqlConnBuild = new SqlConnectionStringBuilder();
        string userName = null, password = null;
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty & textBox2.Text != String.Empty)
            {
                userName = textBox1.Text;
                password = textBox2.Text;
                SqlConnBuild.DataSource = @"A-305-05\АдылкановМ";
                SqlConnBuild.InitialCatalog = "MyDB";
                SqlConnBuild.UserID = userName;
                SqlConnBuild.Password = password;
                SqlConnection conn = new SqlConnection(SqlConnBuild.ConnectionString);
                try {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    MessageBox.Show("Вы вошли!");
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                conn.Close();
            }
        }
    }
}
