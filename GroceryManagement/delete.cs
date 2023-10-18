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
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (deletetxt.Text=="")
            {
                MessageBox.Show("Enter the Product name");
            }
            else
            {
                try
                {
                    connect obj = new connect();
                    obj.con.ConnectionString = obj.locate;
                    obj.con.Open();
                    String insertdata = "delete from Items where iname='"+ deletetxt.Text +"'";
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
            this.Hide();
        }

        private void deletetxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
