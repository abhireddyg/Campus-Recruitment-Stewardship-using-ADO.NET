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

namespace CRS_ADO_N
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);


            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            //string query = "SELECT s.FName,s.Lname,s.Email,s.YearOfStudy FROM Student s INNER JOIN TPO t ON s.CCode = t.InstCode Where Username = @Username ";
            string query = "Select * from Students where Username = @Username";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", Form3.x);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string fname = reader["FName"].ToString().ToUpper();
                        label1.Text = "HELLO, " + fname + " !";
                        textBox1.Text = reader["FName"].ToString().ToUpper();
                        textBox2.Text = reader["LName"].ToString().ToUpper();
                        textBox3.Text = reader["Phone"].ToString();
                        textBox4.Text = reader["Email"].ToString();
                        textBox5.Text = reader["State"].ToString().ToUpper();
                        textBox6.Text = reader["Dist"].ToString().ToUpper();
                        textBox7.Text = reader["Addr"].ToString().ToUpper();
                        dateTimePicker1.Text = reader["DOB"].ToString();
                        listBox1.Text = reader["Sex"].ToString().ToUpper();
                        textBox8.Text = reader["cName"].ToString().ToUpper();
                        textBox9.Text = reader["RegNo"].ToString().ToUpper();
                        textBox10.Text = reader["CCOde"].ToString().ToUpper();
                        textBox11.Text = reader["YearOfStudy"].ToString();
                        textBox12.Text = reader["Percentage"].ToString();
                        textBox13.Text = reader["CAddr"].ToString().ToUpper();
                        textBox14.Text = reader["Username"].ToString();

                    }
                }
            }
        }



        private void UpdatStudentData()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "UPDATE Students SET FName = @FName, LName = @LName, Phone = @Phone , Email = @Email, State = @State, Dist= @Dist , Addr = @Addr, Percentage = @Percentage,DOB = @DOB WHERE Username = @Username";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@LName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@State", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Dist", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Addr", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Percentage",textBox12.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);



                    // Add other parameters as necessary
                    cmd.Parameters.AddWithValue("@Username", Form3.x);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data updated successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdatStudentData();
            Form9 form9 = new Form9();
            form9.ShowDialog();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only Number's", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
form11.ShowDialog();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult updateData  = MessageBox.Show("Do you want to Update data?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (updateData == DialogResult.Yes)
            {
                UpdatStudentData();
                MessageBox.Show("Data Updated Successfully", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Not Updated","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult result = MessageBox.Show("Do you want to Log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button7.BackColor = SystemColors.HotTrack;
                button7.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("You Logged Out Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form2 f = new Form2();
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
