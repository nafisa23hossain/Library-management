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
    public partial class MyBook : Form
    {
        public MyBook()
        {
            InitializeComponent();

        }

        public int uId=UserLogIn.userId;

        
        void BindData()
        {

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BookTable WHERE id in (SELECT bookId FROM MyBook WHERE userId = '"+uId+"' )", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE MyBook WHERE bookId=@bookId", con);
            cmd.Parameters.AddWithValue("@bookId", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";

            BindData();
        }

        private void MyBook_Load(object sender, EventArgs e)
        {
            
            BindData();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPortal ad = new UserPortal();
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
