using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AdminDash : Form
    {
        public AdminDash()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBook adminPanel = new AddBook();
            adminPanel.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Details dt = new Details();
            dt.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateBook ub = new UpdateBook();
            ub.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteBook db = new DeleteBook();
            db.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ControlUser cu = new ControlUser();
            cu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogIn ad = new AdminLogIn();
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
