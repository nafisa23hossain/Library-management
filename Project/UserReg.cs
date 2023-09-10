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
    public partial class UserReg : Form
    {
        public UserReg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Normal_user(username,password,gmail,address,mobile,age,gender) VALUES(@username, @password, @gmail, @address, @mobile, @age, @gender)", con);
                String username = textBox1.Text;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                String gmail = textBox3.Text;
                cmd.Parameters.AddWithValue("@gmail", gmail);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@mobile", textBox5.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@gender", textBox7.Text);
                if (username == "" || username.StartsWith("_"))
                {
                    MessageBox.Show("Insert a valid name!");
                }

                if (!gmail.Contains('@'))
                {
                    MessageBox.Show("Enter a valid gmail address!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";


                    this.Hide();
                    UserLogIn userPanel = new UserLogIn();
                    userPanel.Show();
                }
            }
            
            catch (Exception)
            {
                MessageBox.Show("Exception found! Please Enter valid data!");
            }



        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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

        private void UserReg_Load(object sender, EventArgs e)
        {

        }
    }
}
