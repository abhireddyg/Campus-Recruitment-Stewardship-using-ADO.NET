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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);

            MessageBox.Show("Institute Data Can't be Modified","Note",MessageBoxButtons.OK,MessageBoxIcon.Information);

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            //string query = "SELECT s.FName,s.Lname,s.Email,s.YearOfStudy FROM Student s INNER JOIN TPO t ON s.CCode = t.InstCode Where Username = @Username ";
            string query = "Select * from TPO where UserID = @UserID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", TPOLogin.tpoid);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        string fname = reader["FName"].ToString().ToUpper();
                        label1.Text = "HELLO, " + fname + "!";
                        textBox1.Text = reader["FName"].ToString().ToUpper();
                        textBox2.Text = reader["LName"].ToString().ToUpper();
                        textBox3.Text = reader["Phone"].ToString();
                        textBox4.Text = reader["Email"].ToString();
                        listBox1.Text = reader["Sex"].ToString().ToUpper();
                        textBox8.Text = reader["InstName"].ToString().ToUpper();
                        textBox9.Text = reader["Affliation"].ToString().ToUpper();
                        textBox10.Text = reader["InstCOde"].ToString().ToUpper();
                        textBox11.Text = reader["YearsOfExp"].ToString();
                        textBox12.Text = reader["EduQualification"].ToString();
                        textBox13.Text = reader["Addr"].ToString().ToUpper();
                        textBox14.Text = reader["UserID"].ToString();



                    }
                }
            }

        }


        private void UpdateTPOData()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "UPDATE TPO SET FName = @FName, LName = @LName, Phone = @Phone , Email = @Email, YearsOfExp = @YearsOfExp, EduQualification = @EduQualification WHERE UserID = @UserID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@LName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
                    cmd.Parameters.AddWithValue("Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("YearsOfExp", textBox11.Text);
                    cmd.Parameters.AddWithValue("EduQualification", textBox12.Text);


                    // Add other parameters as necessary
                    cmd.Parameters.AddWithValue("@UserID", TPOLogin.tpoid);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data updated successfully.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateTPOData();
            Form13 form13 = new Form13();
            form13.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.ShowDialog();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button7.BackColor = SystemColors.HotTrack;
                button7.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("You Logged Out Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TPOLogin f = new TPOLogin();
                f.ShowDialog();
                this.Hide();
            }
            else
            {

                button7.BackColor = SystemColors.MenuHighlight;
                button7.ForeColor = SystemColors.ControlText;
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16();
            f.ShowDialog();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
                form13.ShowDialog();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only Number's", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
