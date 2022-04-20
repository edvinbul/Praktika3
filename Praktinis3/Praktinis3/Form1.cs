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
    public partial class Form1 : Form
    {

        bool buttonPressed = false;

        public Form1()

        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            buttonPressed = true;
            LoginU loginU = new LoginU();
            loginU.admin = true;
            loginU.Show();
            Close();
        }

        private void registration_Click(object sender, EventArgs e)
        {
            buttonPressed = true;
            Form2 form2 = new Form2();
            form2.Show();
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            buttonPressed = true;
            LoginU loginU = new LoginU();
            loginU.admin = false;
            loginU.Show();
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!buttonPressed)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonPressed = true;
            Person.Authorized = false;
            Person.Admin = false;
            new ProductsForm().Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonPressed = true;
           SellerLog sellerLog = new SellerLog();
            sellerLog.seller = false;
           sellerLog.Show();
            Close();
        }
    }
}
