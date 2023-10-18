using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GroceryManagement
{
    class connect
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public String locate = @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Users\Devyani\Desktop\GroceryManagement\GroceryManagement\Database1.mdf';Integrated Security=True;User Instance=True";
    }
}
