using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GroceryManagement
{
    public partial class Login : Form
    {
        public static Login instance2;
        public Login()
        {
            InitializeComponent();
            instance2 = this;
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register obj = new Register();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect c = new connect();
                c.con.ConnectionString = c.locate;
                c.con.Open();
                string selectQuery = "select uname from Users where uname='" + user_id.Text + "' and passw='" + pass.Text + "'";
                SqlCommand cmd = new SqlCommand(selectQuery,c.con);
                String s1 = (String)cmd.ExecuteScalar();

                if (user_id.Text == s1)
                {
                    Grocery u = new Grocery();
                    connect ob = new connect();
                    ob.con.ConnectionString = ob.locate;
                    ob.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Items", ob.con);
                    DataTable dtb = new DataTable();
                    sda.Fill(dtb);
                    Grocery.instance.dataGrid1.DataSource = dtb;
                    u.Show();
                    this.Hide();
                    MessageBox.Show("Login Successful");
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password !!!");
                }
                c.con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid Username or Password !!!" + ex);
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_pass ad = new Admin_pass();
            ad.Show();
        }

        private void user_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
