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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public int uId = UserLogIn.userId;
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Payment WHERE userid='"+uId+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            BindData();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;User ID=sa;Password=************");
            SqlDataAdapter da = new SqlDataAdapter(" SELECT count(*) FROM Payment WHERE userid = '" + uId + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                label1.Text = "Your Due is 0";
            }
            else
            {
                label1.Text = "Your Due is 100";
            }



            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-BU4FCAFF;Initial Catalog=Library;Persist Security Info=True;User ID=sa;Password=************");
            con.Open();
            int taka = Convert.ToInt32(textBox1.Text);

            if(label1.Text=="Your Due is 100"){
                if (taka == 100)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Payment(userid,paymentid) VALUES ('" + uId + "','" + taka + "')", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    textBox1.Text = "";
                    MessageBox.Show("Your payment has been paid successfully!");
                    label1.Text = "Your Due is 0";
                }
                else
                {
                    MessageBox.Show("Your have to pay only 100 taka per month!");
                }
            }
            else{
                MessageBox.Show("Your already paid for this month!");
            }

            BindData();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPanel ad = new UserPanel();
            ad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start s = new Start();
            s.Show();
        }
    }
}
