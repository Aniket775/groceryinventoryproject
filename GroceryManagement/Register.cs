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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String gen = null;
            if (String.IsNullOrEmpty(user_name.Text) || String.IsNullOrEmpty(user_uname.Text) || String.IsNullOrEmpty(user_email.Text) || String.IsNullOrEmpty(user_pass.Text) || String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please fill All Details");
            }
            else
            {
                if (radioButton1.Checked)
                {
                    gen = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    gen = radioButton2.Text;
                }
                else if (radioButton3.Checked)
                {
                    gen = radioButton3.Text;
                }

                try
                {
                    connect obj = new connect();
                    obj.con.ConnectionString = obj.locate;
                    obj.con.Open();
                    String insertdata = "insert into Users values('" + user_name.Text + "','" + user_uname.Text + "','" + user_email.Text + "','" + user_pass.Text + "','" + gen + "')";
                    obj.cmd.Connection = obj.con;
                    obj.cmd.CommandText = insertdata;
                    obj.cmd.ExecuteNonQuery();
                    obj.con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user_name.Clear();
            user_uname.Clear();
            user_email.Clear();
            user_pass.Clear();
            textBox5.Clear();
        }

        private void user_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
