using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Praktinis3
{
    using Core;

    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();

            SetCategoriesList();
        }

        void SetCategoriesList()
        {
            listBox1.Items.Clear();

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
                        listBox1.Items.Add(reader["name"].ToString());
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
            int index = listBox1.SelectedIndex;
            if(index < 0)
            {
                MessageBox.Show("Select a category to delete it.");
            }
            else
            {
                try
                {
                    SqlConnection sqlConnection = Sql.GetSqlConnection();
                    sqlConnection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE name=@name", sqlConnection);
                    command.Parameters.AddWithValue("@name", listBox1.Items[listBox1.SelectedIndex].ToString());

                    command.ExecuteNonQuery();
                    sqlConnection.Close();

                    SetCategoriesList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new AddCategoryForm().ShowDialog();
            SetCategoriesList();
        }
    }
}
