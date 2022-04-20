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
    public partial class Seller : Form
    {
        List<int> products;
        

        public Seller()
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
                    personNameLabel.Text = Person.Name;
                }
            }
            else
            {
                personNameLabel.Visible = false;
            }
        }
       

        private void addProductButton_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
            SetProductsList();
        }

        private void SetProductsList()
        {
            listBox1.Items.Clear();

            products = new List<int>();

            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query;

                button1.Text = "Show All";
                query = "Select Products.id AS id, Products.name AS name from Products";
                

                SqlCommand command = new SqlCommand(query, sqlConnection);
               

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
        

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                int id = products[index];
                new ProductForm(id).ShowDialog();
                SetProductsList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetProductsList();
        }

        private void Seller_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
