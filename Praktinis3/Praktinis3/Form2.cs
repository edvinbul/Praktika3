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

    public partial class Form2 : Form
    {
        bool registered = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void register_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                error = true;
            }
            else if (String.IsNullOrEmpty(textBox2.Text) == true)
            {
                error = true;
            }
            else if (String.IsNullOrEmpty(textBox4.Text) == true)
            {
                error = true;
            }
            else if (String.IsNullOrEmpty(textBox5.Text) == true)
            {
                error = true;
            }

            DateTime birthDate = DateTime.Today;
            if (!error)
            {
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    if (!DateTime.TryParse(textBox3.Text, out birthDate))
                    {
                        error = true;
                    }
                    else if (DateTime.Today < birthDate)
                    {
                        error = true;
                    }
                }
                else
                {
                    error = true;
                }
            }


            if (!error)
            {
                Person.Name = textBox1.Text.Trim();
                Person.Surname = textBox2.Text.Trim();
                Person.Login = textBox5.Text.Trim();
                Person.BDate = birthDate;

                if (Person.GetAge() < 18)
                {
                    MessageBox.Show("You too young for registration)","Attention!");


                }
                else
                {
                    try
                    {
                        SqlConnection sqlConnection = Sql.GetSqlConnection();
                        sqlConnection.Open();

                        SqlCommand command = new SqlCommand("INSERT INTO Client (name, surname, password, bdate, login) OUTPUT INSERTED.ID VALUES (@username, @surname, @password, @bdate, @login)", sqlConnection);
                        command.Parameters.AddWithValue("@username", textBox1.Text.Trim());
                        command.Parameters.AddWithValue("@surname", textBox2.Text.Trim());
                        command.Parameters.AddWithValue("@password", textBox4.Text.Trim());
                        command.Parameters.AddWithValue("@bdate", $"{birthDate.Year}/{birthDate.Month}/{birthDate.Day}");
                        command.Parameters.AddWithValue("@login", textBox5.Text.Trim());

                        Person.Id = (int)command.ExecuteScalar();

                        sqlConnection.Close();

                        registered = true;
                        Person.Authorized = true;
                        Person.Admin = false;

                        new ProductsForm().Show();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please, enter your information correctly", "Attention!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!registered)
            {
                Form1 form = new Form1();
                form.Show();
            }
        }
    }
}
