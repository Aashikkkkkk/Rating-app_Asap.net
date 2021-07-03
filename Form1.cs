using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (username.Text == "prakash" && password.Text == "prakash")
            {
                Criteria ram = new Criteria();

                MessageBox.Show("Ram is very good boy");
                ram.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Ram is nothing");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FeedbackForm formram = new FeedbackForm();
            formram.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
