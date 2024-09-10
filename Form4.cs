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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (string.IsNullOrEmpty(textBox15.Text) || textBox16.Text != textBox15.Text)
                {
                    MessageBox.Show("Password Doesn't Match", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox15.Text = null;
                    textBox16.Text = null;
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
                    con.Open();

                    // Check for existing Username, Email, or Phone
                    SqlCommand checkCmd = new SqlCommand("SELECT Username, Email, Phone FROM Students WHERE Username = @Username OR Email = @Email OR Phone = @Phone", con);
                    checkCmd.Parameters.AddWithValue("@Username", textBox14.Text);
                    checkCmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    checkCmd.Parameters.AddWithValue("@Phone", Decimal.Parse(textBox3.Text));

                    SqlDataReader reader = checkCmd.ExecuteReader();

                    bool exists = false;
                    string fieldName = "";

                    while (reader.Read())
                    {
                        if (reader["Username"].ToString() == textBox14.Text)
                        {
                            fieldName = "Username";
                            exists = true;
                            break;
                        }
                        if (reader["Email"].ToString() == textBox4.Text)
                        {
                            fieldName = "Email";
                            exists = true;
                            break;
                        }
                        if (reader["Phone"].ToString() == textBox3.Text)
                        {
                            fieldName = "Phone Number";
                            exists = true;
                            break;
                        }
                    }

                    reader.Close();

                    if (exists)
                    {
                        MessageBox.Show($"{fieldName} Already Exists", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Students (Username, Pass, FName, LName, Sex, DOB, Phone, Email, State, Dist, Addr, CName, CCode, RegNo, YearOfStudy, Percentage, CAddr) VALUES (@Username, @Pass, @FName, @LName, @Sex, @DOB, @Phone, @Email, @State, @Dist, @Addr, @CName, @CCode, @RegNo, @YearOfStudy, @Percentage, @CAddr)", con);
                        cmd.Parameters.AddWithValue("@Username", textBox14.Text);
                        cmd.Parameters.AddWithValue("@Pass", textBox16.Text);
                        cmd.Parameters.AddWithValue("@FName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@LName", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Phone", Decimal.Parse(textBox3.Text));
                        cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Sex", listBox1.Text);
                        cmd.Parameters.AddWithValue("@State", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Dist", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Addr", textBox7.Text);
                        cmd.Parameters.AddWithValue("@CName", textBox8.Text);
                        cmd.Parameters.AddWithValue("@RegNo", textBox9.Text);
                        cmd.Parameters.AddWithValue("@CCode", textBox10.Text);
                        cmd.Parameters.AddWithValue("@YearOfStudy", int.Parse(textBox11.Text));
                        cmd.Parameters.AddWithValue("@Percentage", int.Parse(textBox12.Text));
                        cmd.Parameters.AddWithValue("@CAddr", textBox13.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form3 f = new Form3();
                            f.ShowDialog();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while inserting data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please agree to the terms and conditions", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }






            private void button2_Click(object sender, EventArgs e)
        {
            Form3 F = new Form3();
            F.ShowDialog();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
