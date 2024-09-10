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

namespace CRS_ADO_N
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.ShowDialog();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                if(textBox9!=null && textBox10.Text == textBox9.Text)
                {

                    //button1.Enabled = true; 
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Company values(@UserId,@Password,@CompName,@ContactName,@Phone,@Email,@Industry,@Website,@Address,@Description)", con);
                    cmd.Parameters.AddWithValue("@UserId", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox10.Text);
                    cmd.Parameters.AddWithValue("@CompName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ContactName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Phone", Decimal.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Industry", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Description", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Website", textBox8.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Registered","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Successfully registered");
                    Form6 f = new Form6();
                    f.ShowDialog();

                }
               // if (textBox9.Text == null || textBox10.Text != textBox9.Text)
                else
                {
                    MessageBox.Show("Password Doesn't Matched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox9.Text = null;
                    textBox10.Text = null;
                }

            }
            else
            {
                MessageBox.Show("Please agree the terms and conditions");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
