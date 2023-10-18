using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GroceryManagement
{
    public partial class Admin : Form
    {

        public Admin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(quantity.Text) || String.IsNullOrEmpty(price.Text) || String.IsNullOrEmpty(category.Text))
            {
                MessageBox.Show("Please fill All Details");
            }
            else
            {
                try
                {
                    connect obj = new connect();
                    obj.con.ConnectionString = obj.locate;
                    obj.con.Open();
                    String insertdata = "insert into Items values('" + name.Text + "','" + quantity.Text + "','" + price.Text + "','" + category.Text + "')";
                    obj.cmd.Connection = obj.con;
                    obj.cmd.CommandText = insertdata;
                    obj.cmd.ExecuteNonQuery();
                    obj.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
            }
            connect ob = new connect();
            ob.con.ConnectionString = ob.locate;
            ob.con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Items",ob.con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            dataGrid.DataSource = dtb;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            name.Text = dataGrid.SelectedRows[0].Cells[1].Value.ToString();
            quantity.Text = dataGrid.SelectedRows[0].Cells[2].Value.ToString();
            price.Text = dataGrid.SelectedRows[0].Cells[3].Value.ToString();
            category.Text = dataGrid.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name.Clear();
            quantity.Clear();
            price.Clear();
            category.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete ds = new delete();
            ds.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect ob = new connect();
            ob.con.ConnectionString = ob.locate;
            ob.con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Items", ob.con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            dataGrid.DataSource = dtb;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }
    }
}
