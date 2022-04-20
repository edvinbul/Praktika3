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
    public partial class Orders : Form
    {
        List<int> products;
        bool liked = false;

        public Orders()
        {
            InitializeComponent();

            if (Person.Authorized)
            {
                personNameLabel.Visible = true;
                if (Person.Admin)
                {
                    personNameLabel.Text = "Admin";
                }
                else
                {
                    personNameLabel.Text = Person.Name + " " + Person.Surname;
                }
            }
            else
            {
                personNameLabel.Visible = false;
            }

            
            likedButton.Visible = Person.Authorized && !Person.Admin;
            liked = false;
            SetProductsList();
        }

        void SetProductsList()
        {
            listBox1.Items.Clear();

            products = new List<int>();

            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query;
              
                    likedButton.Text = "Show All";
                    query = "Select Products.id AS id, Products.name AS name from Products, Likes WHERE Products.id=Likes.productid";
               

                SqlCommand command = new SqlCommand(query, sqlConnection);
                if (liked)
                {
                    command.Parameters.AddWithValue("@user", Person.Id);
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["name"].ToString());
                        products.Add((int)reader["id"]);
                    }
                }

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Orders_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                int id = products[index];
                new OrdersProduct(id).ShowDialog();
                SetProductsList();
            }
        }

        private void likedButton_Click(object sender, EventArgs e)
        {
            liked = !liked;
            SetProductsList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     
        private void personNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
