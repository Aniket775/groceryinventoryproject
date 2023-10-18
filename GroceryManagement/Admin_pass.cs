using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GroceryManagement
{
    public partial class Admin_pass : Form
    {
        public Admin_pass()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void deletetxt_TextChanged(object sender, EventArgs e)
        {

        }
        String pass = "admin";
        private void button1_Click(object sender, EventArgs e)
        {
            String txt = deletetxt.Text;
            if (pass == txt)
            {
                Admin ad = new Admin();
                ad.Show();
                Login lg = new Login();
                lg.Hide();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
    }
}
