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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TPOLogin login = new TPOLogin();
            login.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {


                if (textBox11.Text == null || textBox12.Text != textBox11.Text)
                {
                    MessageBox.Show("Password Mismatched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // MessageBox.Show("Password Doesn't Matched");
                    textBox11.Text = null;
                    textBox12.Text = null;
                }
                else
                {

                    //button1.Enabled = true; 
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TPO values(@UserID,@Password,@FName,@LName,@Email,@Phone,@Sex,@InstName,@InstCode,@Affliation,@YearsOfExp,@EduQualification,@Addr)", con);
                    cmd.Parameters.AddWithValue("@UserID", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox12.Text);
                    cmd.Parameters.AddWithValue("@FName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@LName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Phone", Decimal.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@YearsOfExp", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Sex", listBox1.Text);
                    cmd.Parameters.AddWithValue("@InstName", textBox6.Text);
                    cmd.Parameters.AddWithValue("@InstCode", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Affliation", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@EduQualification", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Addr", textBox9.Text);
                    cmd.ExecuteNonQuery();
                    //con.Close();
                    MessageBox.Show("TPO Registration Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Successfully registered");
                    TPOLogin f = new TPOLogin();
                    f.ShowDialog();
                    this.Hide();

                }

            }
            else
            {
                MessageBox.Show("Please agree the terms and conditions");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
