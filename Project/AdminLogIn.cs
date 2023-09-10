using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AdminLogIn : Form
    {
        public AdminLogIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            SqlDataAdapter da = new SqlDataAdapter(" SELECT count(*) FROM Admin_user WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                AdminDash adminPanel = new AdminDash();
                adminPanel.Show();
            }
            else
            {
                MessageBox.Show("Enter a Valid Username and Password!");
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start ad = new Start();
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start s = new Start();
            s.Show();
        }
    }
}
