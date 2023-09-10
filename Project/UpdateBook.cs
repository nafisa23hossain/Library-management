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
    public partial class UpdateBook : Form
    {
        public UpdateBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BookTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE BookTable SET name=@name , author=@author , genre=@genre , release=@release WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@author", textBox2.Text);
                cmd.Parameters.AddWithValue("@genre", textBox3.Text);
                cmd.Parameters.AddWithValue("@release", date.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                date.Text = "";

                BindData();
            }
            catch (Exception)
            {
                MessageBox.Show("Exception found! Please Enter valid data!");
            }
        }

        private void UpdateBook_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDash ad = new AdminDash();
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
