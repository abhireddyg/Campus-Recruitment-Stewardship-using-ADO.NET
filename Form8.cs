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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace CRS_ADO_N
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.ShowDialog();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
            //string a = "WELCOME";
            //label1.Text =  a +", " + Form3.x.ToUpper();
            label1.Text =   Form3.x.ToUpper();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.ShowDialog();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            button4.BackColor = SystemColors.MenuHighlight;
            button4.ForeColor = SystemColors.MenuHighlight;
            // MessageBox.Show("Do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result = MessageBox.Show("Do you want to Log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                MessageBox.Show("You Logged Out Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form3 f = new Form3();
                f.ShowDialog();
                this.Hide();
            }
            else
            {

                button4.BackColor = SystemColors.MenuHighlight;
                button4.ForeColor = SystemColors.ControlText;
                // Code to handle cancellation
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 28);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 23);

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Font = new Font(button2.Font.FontFamily, 28);

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font(button2.Font.FontFamily, 23);

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.FontFamily, 28);

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.FontFamily, 23);

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.Font = new Font(button4.Font.FontFamily, 28);

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Font = new Font(button4.Font.FontFamily, 23);

        }
    }
}
