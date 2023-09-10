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
    public partial class AllBook : Form
    {
        public AllBook()
        {
            InitializeComponent();
        }


        int count;
        public int uId = UserLogIn.userId;



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

        private int Counting()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            SqlDataAdapter da = new SqlDataAdapter("SELECT count(*) FROM MyBook WHERE userid='"+uId+"'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return Convert.ToInt32(dt.Rows[0][0]);
        }
        private void AllBook_Load(object sender, EventArgs e)
        {


            count = Counting();
            BindData();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (count <= 4)
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO MyBook(userId,bookId) VALUES('" + uId + "','" + Convert.ToInt32(textBox1.Text) + "')", con);

                //cmd.Parameters.AddWithValue("@name", textBox1.Text);

                cmd.ExecuteNonQuery();

                con.Close();
                textBox1.Text = "";
                MessageBox.Show("Successfully Added on My Book List!");
                count = Counting();
            }
            else
            {
                MessageBox.Show("You already have 4 books in your list!");
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPortal ad = new UserPortal();
            ad.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start s = new Start();
            s.Show();
        }
    }
}
