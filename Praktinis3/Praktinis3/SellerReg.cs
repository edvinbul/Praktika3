using Core;
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

namespace Praktinis3
{
    public partial class SellerReg : Form
    {
        bool registered = false;
        public SellerReg()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
           
                if(error != true)
            {
                try
                {
                    SqlConnection sqlConnection = Sql.GetSqlConnection();
                    sqlConnection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Seller (Id, CompanyName, CompanyEmail, login, password) OUTPUT INSERTED.ID VALUES (@id, @name, @email, @login, @password)", sqlConnection);
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    command.Parameters.AddWithValue("@email", textBox2.Text);
                    command.Parameters.AddWithValue("@login", textBox3.Text);
                    command.Parameters.AddWithValue("@password", textBox4.Text);
                    command.Parameters.AddWithValue("@id", textBox5.Text);

                    Person.Id = (int)command.ExecuteScalar();

                    sqlConnection.Close();

                    registered = true;
                    Person.Authorized = true;
                    Person.Admin = false;

                    MessageBox.Show("Seller successful registed");
                    //new Seller().Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please, enter your information correctly", "Attention!");
            }
                   
                


        }
        private void SellerReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!registered)
            {
                Form1 form = new Form1();
                form.Show();
            }
        }
    }
}
