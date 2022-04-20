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

    public partial class AddProductForm : Form
    {
        

        public AddProductForm()
        {
            InitializeComponent();
            SetCategoriesList();
           
        }

        void SetCategoriesList()
        {
            comboBox1.Items.Clear();

            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query = "Select name from Categories";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["name"].ToString());
                    }
                }

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.BMP;*.JPG;*GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            openFileDialog.Title = "Select an image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Error","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select an image.", "Attention!");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please, enter your information correctly", "Attention!");
                return;
            }

            float cost = 0;
            if (!float.TryParse(textBox1.Text, out cost))
            {
                MessageBox.Show("Please, enter your information correctly", "Attention!");
                return;
            }

            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query = "Select id from Categories Where name=@name";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@name", comboBox1.Text);

                int categoryId = -1;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       categoryId = (int)reader["id"];
                    }
                }

                sqlConnection.Close();

                byte[] data = null;
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = stream.ToArray();
                }

                string imageString = Convert.ToBase64String(data);

                sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                command = new SqlCommand("INSERT INTO Products (name, category, image, description, cost) VALUES (@name, @category, @image, @description, @cost )", sqlConnection);
                command.Parameters.AddWithValue("@name", textBox2.Text);
                command.Parameters.AddWithValue("@category", categoryId);
                command.Parameters.AddWithValue("@image", imageString);
                command.Parameters.AddWithValue("@description", textBox3.Text);
                command.Parameters.AddWithValue("@cost", cost);

                command.ExecuteNonQuery();
                sqlConnection.Close();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void categoriesButton_Click(object sender, EventArgs e)
        {
            new CategoriesForm().ShowDialog();
            SetCategoriesList();
        }

       
    }
}
