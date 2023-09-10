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
    public partial class ControlUser : Form
    {
        public ControlUser()
        {
            InitializeComponent();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Normal_user", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Normal_user SET valid = 0 WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            textBox4.Text = "";

            BindData();
        }

        private void ControlUser_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE Normal_user WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox4.Text = "";

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
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Normal_user SET valid = 1 WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            textBox4.Text = "";

            BindData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start s = new Start();
            s.Show();
        }
    }
}
