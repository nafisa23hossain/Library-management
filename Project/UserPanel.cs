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
    public partial class UserPanel : Form
    {
        public String username;
        public UserPanel()
        {
            InitializeComponent();
        }
        private void UserPanel_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(username);
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment p = new Payment();
            p.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPortal dash = new UserPortal();
            dash.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogIn ub = new UserLogIn();
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
