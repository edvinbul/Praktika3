using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;
using Core;

namespace Praktinis3
{
    public partial class SellerLog : Form
    {
        public bool seller = false;
        bool loginSuccess = false;
        public SellerLog()
        {
            InitializeComponent();
        }

        private void login1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    SqlConnection sqlConnection = Sql.GetSqlConnection();
                    sqlConnection.Open();

                    string query;
                    
                    query = "Select CompanyName, CompanyEmail from Seller Where login = @login and password = @password";
                    
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@login", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox2.Text);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Person.Name = reader["CompanyName"].ToString().Trim();
                            Person.Surname = reader["CompanyEmail"].ToString().Trim();
                            
                            
                               
                            
                            Person.Login = textBox1.Text.Trim();
                            Person.Authorized = false;
                            Person.Seller = seller;

                            new Seller().Show();
                            loginSuccess = true;
                          
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Your login or password is wrong!", "Attention!");
                        }
                    }

                    sqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void SellerLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginSuccess)
            {
                Form1 form = new Form1();
                form.Show();
            }
        }
    }
}
