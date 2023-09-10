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
    public partial class UserLogIn : Form
    {
        
        public UserLogIn()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        public String username;
        public static int userId;
        public void FindId()
        {
            SqlConnection con = new SqlConnection("data source=laptop-bu4fcaff;initial catalog=library;user id=sa;password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from normal_user where username='" + username + "'", con);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int userid = Convert.ToInt32(reader["id"]);
                    userId = userid;

                }
            }
            con.Close();

            //MessageBox.Show("" + userId);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            username = textBox1.Text;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            SqlDataAdapter da = new SqlDataAdapter(" SELECT count(*) FROM Normal_user WHERE username = '" + username + "' AND password = '" + textBox2.Text + "' AND valid= 1", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {

                this.Hide();



                FindId();


                UserPanel up = new UserPanel();
                up.username = username;
                up.Show();
            }
            else
            {
                MessageBox.Show("Enter a Valid Username and Password Or You may didn't pay your bill proprly!");
            }


        }
        
        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            UserStart ub = new UserStart();
            ub.Show();
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
