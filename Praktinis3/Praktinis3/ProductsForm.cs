using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Praktinis3
{
    using Core;

    public partial class ProductsForm : Form
    {

        List<int> products;
        bool liked = false;

        public ProductsForm()
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

            addProductButton.Visible = Person.Authorized && Person.Admin;
            likedButton.Visible = Person.Authorized && !Person.Admin;
            button3.Visible = Person.Authorized && Person.Admin;
            button2.Visible = Person.Authorized && Person.Admin;
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
                if (liked)
                {
                    likedButton.Text = "Show All";
                    query = "Select Products.id AS id, Products.name AS name from Products, Likes WHERE userid=@user AND Products.id=Likes.productid";
                }
                else
                {
                    likedButton.Text = "Show Rented";
                    query = "Select id, name from Products";
                }

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

        private void ProductsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
            SetProductsList();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if(index >= 0)
            {
                int id = products[index];
                new ProductForm(id).ShowDialog();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void personNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SellerReg().ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Orders().ShowDialog();
        }
    }
}
