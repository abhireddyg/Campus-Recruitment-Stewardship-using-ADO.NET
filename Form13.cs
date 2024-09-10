using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRS_ADO_N
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);

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
                        label1.Text = reader["FName"].ToString().ToUpper();
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

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete your Profile?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Code to delete the record

                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TPO WHERE UserID = @UserID", con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", TPOLogin.tpoid);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Profile deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form3 f = new Form3();
                f.ShowDialog();
                this.Hide();
            }
            else
            {
                // Code to handle cancellation
                MessageBox.Show("Deletion cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16();
            f.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
            form15.ShowDialog();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form17 form17 = new Form17();
            form17.ShowDialog();
            this.Hide();
        }
    }
}
