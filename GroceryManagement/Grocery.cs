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
    public partial class Grocery : Form
    {
        int amt = 0;
         
        public static Grocery instance;
        public Grocery()
        {
            InitializeComponent();
            instance = this;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Grocery_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        
        private void button2_Click(object sender, EventArgs e)
        {

        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login nl = new Login();
            nl.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            connect ob = new connect();
            ob.con.ConnectionString = ob.locate;
            ob.con.Open();
            string selectQuery3 = "select iquan from Items where iname='" + itemtxt.Text + "'";
            SqlCommand cmd3 = new SqlCommand(selectQuery3, ob.con);
            int s7 = (int)cmd3.ExecuteScalar();
            int s8 = Convert.ToInt32(s7);
            int s10 = Convert.ToInt32(quantxt.Text);

            connect c = new connect();
            c.con.ConnectionString = c.locate;
            c.con.Open();
            string selectQuery = "select iprice from Items where iname='" + itemtxt.Text + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, c.con);
            int s1 = (int)cmd.ExecuteScalar();
            int s6 = Convert.ToInt32(s1);
            int s2 = Convert.ToInt32(quantxt.Text);
            int s3 = s6 * s2;
            c.con.Close();

            if (String.IsNullOrEmpty(itemtxt.Text) || String.IsNullOrEmpty(quantxt.Text) )
            {
                MessageBox.Show("Please fill All Details");
            }
            else if (s8 >= s10)
            {
                try
                {
                    connect obj = new connect();
                    obj.con.ConnectionString = obj.locate;
                    obj.con.Open();
                    String insertdata = "insert into Bill values('" + itemtxt.Text + "','" + quantxt.Text + "','" + s3 + "')";
                    amt = amt + s3;
                    String amts = Convert.ToString(amt);
                    label7.Text = "Total : " + amts;
                    obj.cmd.Connection = obj.con;
                    obj.cmd.CommandText = insertdata;
                    obj.cmd.ExecuteNonQuery();
                    obj.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                int s9 = s8 - s10;
                String update = "update Items set iquan = '" + s9 + "'where iname='" + itemtxt.Text + "'";
                ob.cmd.Connection = ob.con;
                ob.cmd.CommandText = update;
                ob.cmd.ExecuteNonQuery();
                ob.con.Close();
            }
            else
            {
                MessageBox.Show("Insufficiant Stock");
            }


            connect ob2 = new connect();
            ob2.con.ConnectionString = ob2.locate;
            ob2.con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Bill", ob2.con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            dataGrid2.DataSource = dtb;
        

            connect ob3 = new connect();
            ob3.con.ConnectionString = ob2.locate;
            ob3.con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select * from Items", ob2.con);
            DataTable dtb1 = new DataTable();
            sda1.Fill(dtb1);
            dataGrid1.DataSource = dtb1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            bill b1 = new bill(amt);
            b1.Show();

            String clname = Convert.ToString(Login.instance2.user_id.Text);
            connect obj = new connect();
            obj.con.ConnectionString = obj.locate;
            obj.con.Open();
            String insertdata = "insert into Bills values('" + clname + "','" + contxt.Text + "','" + amt + "')";
            obj.cmd.Connection = obj.con;
            obj.cmd.CommandText = insertdata;
            obj.cmd.ExecuteNonQuery();
            obj.con.Close();

            
            connect c1 = new connect();
            c1.con.ConnectionString = c1.locate;
            c1.con.Open();
            string removedata = "Delete from Bill";
            c1.cmd.Connection = c1.con;
            c1.cmd.CommandText = removedata;
            c1.cmd.ExecuteNonQuery();
            c1.con.Close();

            connect ob = new connect();
            ob.con.ConnectionString = ob.locate;
            ob.con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Bill", ob.con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            dataGrid2.DataSource = dtb;
        }

        private void contxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
