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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO BookTable(name,author,genre,release) VALUES(@name, @author, @genre, @release)", con);

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
                MessageBox.Show("Successfully inserted!");
                BindData();
            }
            catch (Exception)
            {
                MessageBox.Show("Exception found! Please Enter valid data!");
            }
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
        private void AddBook_Load(object sender, EventArgs e)
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
