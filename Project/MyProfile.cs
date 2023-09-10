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
    public partial class MyProfile : Form
    {
        public MyProfile()
        {
            InitializeComponent();
        }
        public int uId = UserLogIn.userId;

        void BindData()
        {

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Normal_user WHERE id = '"+uId+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=laptop-bu4fcaff;initial catalog=library;user id=sa;password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM normal_user WHERE id='" + uId + "'", con);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String username= Convert.ToString(reader["username"]);
                    String password = Convert.ToString(reader["password"]);
                    String gmail = Convert.ToString(reader["gmail"]);
                    String address = Convert.ToString(reader["address"]);
                    String mobile = Convert.ToString(reader["mobile"]);
                    String age = Convert.ToString(reader["age"]);
                    String gender = Convert.ToString(reader["gender"]);
                    textBox1.Text = username;
                    textBox2.Text = password;
                    textBox3.Text = gmail;
                    textBox4.Text = address;
                    textBox5.Text = mobile;
                    textBox6.Text = age;
                    textBox7.Text = gender;


                }
            }
            con.Close();



            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPortal up = new UserPortal();
            up.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Normal_user SET username=@username,password=@password , gmail=@gmail , address=@address, mobile=@mobile , age=@age, gender=@gender WHERE id='" + uId + "'", con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@gmail", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@mobile", textBox5.Text);
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(textBox6.Text));
                cmd.Parameters.AddWithValue("@gender", textBox7.Text);

                cmd.ExecuteNonQuery();
                con.Close();


                BindData();
            }
            catch (Exception)
            {
                MessageBox.Show("Exception found! Please Enter valid data!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start s = new Start();
            s.Show();
        }
    }
}
