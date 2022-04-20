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

    public partial class AddCommentaryForm : Form
    {
        int productId;

        public AddCommentaryForm(int id)
        {
            InitializeComponent();

            productId = id;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please, enter text", "Attention!");
                return;
            }

            try
            {
                SqlConnection sqlConnection = Sql.GetSqlConnection();
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Commentaries (text, productid, userid, add_date) VALUES (@text,@productid,@user,@date)", sqlConnection);
                command.Parameters.AddWithValue("@text", textBox2.Text);
                command.Parameters.AddWithValue("@productid", productId);
                command.Parameters.AddWithValue("@user", Person.Id);
                command.Parameters.AddWithValue("@date", DateTime.Now);

                command.ExecuteNonQuery();
                sqlConnection.Close();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
