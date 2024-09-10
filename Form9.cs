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
    public partial class Form9 : Form
    {

        public static string id;
        public Form9()
        {
            InitializeComponent();
        }

        private void LoadStu()
        {
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


                        id = textBox9.Text;
                    }
                }
            }
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
      

            LoadStu();
            

        }

       

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // CODE TO DELETE THE SPECIFIC PROFILE RECORD
            textBox14.Text = Form3.x;

            DialogResult result = MessageBox.Show("Do you really want to delete your Profile?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Code to delete the record

                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE Username = @Username", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", textBox14.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Profile deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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


        private void studentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void studentBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();  
            form8.ShowDialog();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.ShowDialog();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.BackColor = SystemColors.HotTrack;
            button7.ForeColor = SystemColors.ButtonHighlight;

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
                // Code to handle cancellation
                button7.BackColor = SystemColors.HotTrack;
                button7.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.ShowDialog();
            this.Hide();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.FontFamily, 28);

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.FontFamily, 23);

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.FontFamily, 28);

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.FontFamily, 23);

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Font = new Font(button6.Font.FontFamily, 28);

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Font = new Font(button6.Font.FontFamily, 23);
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.Font = new Font(button7.Font.FontFamily, 28);

        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.Font = new Font(button7.Font.FontFamily, 23);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form18 f = new Form18();
            f.ShowDialog();
            this.Hide();    
        }
    }
}
