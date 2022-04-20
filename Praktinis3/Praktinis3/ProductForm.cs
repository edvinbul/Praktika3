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

    public partial class ProductForm : Form
    {
        int id;
        bool liked = false;

        public ProductForm(int productId)
        {
            InitializeComponent();
            id = productId;

            SetProductData(productId);

            deleteButton.Visible = Person.Authorized && Person.Admin;
            rentButton.Visible = Person.Authorized && !Person.Admin;
            addCommentaryButton.Visible = Person.Authorized;


            liked = false;
            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query = "Select id from Likes WHERE productid=@id AND userid=@user";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@user", Person.Id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        liked = true;
                    }
                }

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetLikeButton();
            LoadCommentaries();
        }

        void SetLikeButton()
        {
            if (liked)
            {
                rentButton.Text = "Cancel";
            }
            else
            {
                rentButton.Text = "Rent";
            }
        }

        void LoadCommentaries()
        {
            commentaryPanel.Visible = false;

            while (commentariesPanel.Controls.Count > 1)
            {
                commentariesPanel.Controls.RemoveAt(1);
            }

            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query = "Select id,text,userid,add_date from Commentaries WHERE productid=@id ORDER BY add_date DESC";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string user = "DELETED";

                        SqlConnection sqlConnection1 = Sql.GetSqlConnection();
                        sqlConnection1.Open();

                        string query1 = "Select name,surname from Client WHERE id=@id";

                        SqlCommand command1 = new SqlCommand(query1, sqlConnection1);
                        command1.Parameters.AddWithValue("@id", reader["userid"]);

                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                user = reader1["name"].ToString().Trim() + " " + reader1["surname"].ToString().Trim();

                            }
                        }

                        sqlConnection1.Close();

                        string date = ((DateTime)reader["add_date"]).ToString("G");
                        string text = reader["text"].ToString();
                        AddCommentaryPanel(reader["id"].ToString(), user + ", " + date, text);
                    }
                }

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AddCommentaryPanel(string id, string title, string text)
        {
            Panel panel = new Panel();
            panel.Name = "CommentaryPanel" + (commentariesPanel.Controls.Count + 1).ToString();
            panel.BorderStyle = commentaryPanel.BorderStyle;
            Size size = commentaryPanel.MaximumSize;
            size.Height = 0;
            panel.MaximumSize = size;
            panel.MinimumSize = commentaryPanel.MinimumSize;
            panel.AutoSize = commentaryPanel.AutoSize;
            panel.Margin = commentaryPanel.Margin;
            panel.AutoScroll = commentaryPanel.AutoScroll;
            panel.AutoSizeMode = commentaryPanel.AutoSizeMode;
            commentariesPanel.Controls.Add(panel);
            panel.Visible = true;

            Label label1 = new Label();
            label1.MaximumSize = commentaryNameLabel.MaximumSize;
            label1.MinimumSize = commentaryNameLabel.MinimumSize;
            label1.AutoSize = commentaryNameLabel.AutoSize;
            label1.Font = commentaryNameLabel.Font;
            panel.Controls.Add(label1);
            label1.Location = commentaryNameLabel.Location;
            label1.Text = title;

            Label label2 = new Label();
            label2.MaximumSize = commentaryTextLabel.MaximumSize;
            label2.MinimumSize = commentaryTextLabel.MinimumSize;
            label2.AutoSize = commentaryTextLabel.AutoSize;
            label2.Font = commentaryTextLabel.Font;
            panel.Controls.Add(label2);
            label2.Location = commentaryTextLabel.Location;
            label2.Margin = commentaryTextLabel.Margin;
            label2.Text = text;

            Button button = new Button();
            button.MaximumSize = deleteCommentaryButton.MaximumSize;
            button.MinimumSize = deleteCommentaryButton.MinimumSize;
            button.AutoSize = deleteCommentaryButton.AutoSize;
            button.Font = deleteCommentaryButton.Font;
            button.Size = deleteCommentaryButton.Size;
            button.BackColor = deleteCommentaryButton.BackColor;
            panel.Controls.Add(button);
            button.Location = deleteCommentaryButton.Location;
            button.Text = deleteCommentaryButton.Text;
            button.Visible = Person.Authorized && Person.Admin;
            button.Name = "DeleteCommentary_" + id;
            button.Click += deleteCommentaryButton_Click;
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

                SqlCommand command = new SqlCommand("DELETE FROM Products WHERE id=@id", sqlConnection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Product successfully deleted", "Attention!");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void likeButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                string query;
                if (liked)
                {
                    query = "DELETE FROM Likes WHERE productid=@id AND userid=@user";
                }
                else
                {
                    query = "INSERT INTO Likes(productid, userid) VALUES(@id, @user)";
                }

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@user", Person.Id);

                command.ExecuteNonQuery();
                sqlConnection.Close();

                liked = !liked;
                SetLikeButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addCommentaryButton_Click(object sender, EventArgs e)
        {
            new AddCommentaryForm(id).ShowDialog();
            LoadCommentaries();
        }

        private void deleteCommentaryButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string str = button.Name.Split('_')[1];
            if (int.TryParse(str, out int index))
            {
                try
                {
                    SqlConnection sqlConnection = Sql.GetSqlConnection();
                    sqlConnection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM Commentaries WHERE id=@id", sqlConnection);
                    command.Parameters.AddWithValue("@id", index);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();

                    commentariesPanel.Controls.Remove(button.Parent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void commentariesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void categoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void costLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
