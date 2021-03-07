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

namespace LoginPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string constring = "Data Source=T2130;Initial Catalog=C#SQL;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) //to ensure connection is open or not
            {
                string q = "Select * from Password";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (textBox1.Text.Equals(dr["UserID"].ToString()) && textBox2.Text.Equals(dr["Password"].ToString()))
                    {
                        MessageBox.Show("match");
                    }
                    else
                    {
                        MessageBox.Show("Does not match");
                    }
                }

            }
        }
    }
}
