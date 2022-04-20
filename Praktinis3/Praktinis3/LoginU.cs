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
namespace Praktinis3
{
    using Core;

    public partial class LoginU : Form
    {
        public bool admin = false;
        bool loginSuccess = false;

        public LoginU()
        {
            InitializeComponent();
            
        }

        private void login1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox4.Text != "")
            {
                try
                {
                    SqlConnection sqlConnection = Sql.GetSqlConnection();
                    sqlConnection.Open();

                    string query;
                    if (admin)
                    {
                        query = "Select name, surname from Admin Where login = @login and password = @password";
                    }
                    else
                    {
                        query = "Select id, name, surname, bdate from Client Where login = @login and password = @password";
                        
                    }
                    

                 

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@login", textBox5.Text);
                    command.Parameters.AddWithValue("@password", textBox4.Text);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Person.Name = reader["name"].ToString().Trim();
                            Person.Surname = reader["surname"].ToString().Trim();
                            if (!admin)
                            {
                                Person.BDate = (DateTime)reader["bdate"];
                                Person.Id = (int)reader["id"];
                            }
                            Person.Login = textBox5.Text.Trim();
                            Person.Authorized = true;
                            Person.Admin = admin;

                            new ProductsForm().Show();
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

        private void LoginU_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginSuccess)
            {
                Form1 form = new Form1();
                form.Show();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
