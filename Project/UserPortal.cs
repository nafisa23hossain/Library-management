using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class UserPortal : Form
    {
        public int username;
        public UserPortal()
        {
            InitializeComponent();
        }

        private void UserPortal_Load(object sender, EventArgs e)
        {
            
        }
        public int Findid()
        {
            
            SqlConnection con = new SqlConnection("data source=laptop-bu4fcaff;initial catalog=library;user id=sa;password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from normal_user where username='"+ username + "'", con);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int userid = Convert.ToInt32(reader["id"]);
                    return userid;
                }
            }
            con.Close();
            return -1;



        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyBook mb = new MyBook();
            mb.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllBook mb = new AllBook();
            mb.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyProfile mb = new MyProfile();
            mb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPanel ad = new UserPanel();
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
