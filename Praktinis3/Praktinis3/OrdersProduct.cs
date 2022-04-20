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
    public partial class OrdersProduct : Form
    {
        int id;
        public OrdersProduct(int productId)
        {
            InitializeComponent();
            id = productId;

            SetProductData(productId);

            

            
            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query = "Select id from Likes WHERE productid=@id AND userid=@user";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@user", Person.Id);

               

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public OrdersProduct()
        {
        }
        void SetProductData(int id)
        {
            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query = "Select name, image, category, description, cost from Products WHERE id=@id";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nameLabel.Text = reader["name"].ToString();
                        descriptionTextBox.Text = reader["description"].ToString();
                        costLabel.Text = reader["cost"].ToString() + "$";

                        byte[] imageBytes = Convert.FromBase64String(reader["image"].ToString());
                        pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(imageBytes), true);

                        categoryLabel.Text = "";

                        SqlConnection sqlConnection1 = Sql.GetSqlConnection();
                        sqlConnection1.Open();

                        string query1 = "Select name from Categories WHERE id=@id";

                        SqlCommand command1 = new SqlCommand(query1, sqlConnection1);
                        command1.Parameters.AddWithValue("@id", reader["category"]);

                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                categoryLabel.Text = reader1["name"].ToString();
                            }
                        }

                        sqlConnection1.Close();
                    }
                }

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Likes WHERE productid=@id", sqlConnection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Order successfully accepted", "Attention!");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void likeButton_Click(object sender, EventArgs e)
        {

        }

        private void Decline_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Likes WHERE productid=@id", sqlConnection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Order successfully declined", "Attention!");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
