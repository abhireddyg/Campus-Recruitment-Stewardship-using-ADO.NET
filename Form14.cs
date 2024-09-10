using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRS_ADO_N
{
    public partial class Form14 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
        private void refreshdata()
        {

            SqlCommand cmd = new SqlCommand("SELECT s.* FROM STUDENTS s INNER JOIN TPO t ON s.CCode = t.InstCode", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        public Form14()
        {
            InitializeComponent();
            LoadStudentData();
            refreshdata();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
            //studentsTableAdapter.Fill(this.cRS1DataSet8.Students);
            
            LoadStudentData();
            refreshdata();

        }

       /* private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.FillBy2(this.cRS1DataSet.Students);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillBy2ToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.FillBy2(this.cRS1DataSet.Students);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.ShowDialog();
            this.Hide();
        }

        private void LoadStudentData()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT s.* FROM STUDENTS s INNER JOIN TPO t ON s.CCode = t.InstCode";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
            form15.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16();
            form16.ShowDialog();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void studentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button5.BackColor = SystemColors.HotTrack;
                button5.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("You Logged Out Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TPOLogin f = new TPOLogin();
                f.ShowDialog();
                this.Hide();
            }
            else
            {

                button5.BackColor = SystemColors.MenuHighlight;
                button5.ForeColor = SystemColors.ControlText;
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string queryCheck = "SELECT COUNT(*) FROM Students WHERE RegNo = @RegNo";
            string queryRetrieve = "SELECT s.FName, s.Lname, s.RegNo, s.Username, s.Email, s.YearOfStudy FROM Students s INNER JOIN TPO t ON s.CCode = t.InstCode WHERE s.RegNo = @RegNo";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // First, check if the registration number exists
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, con))
                {
                    cmdCheck.Parameters.AddWithValue("@RegNo", textBox1.Text);

                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show($"Register No {textBox1.Text} not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxes();
                        return;
                    }
                }

                // If it exists, retrieve the details
                using (SqlCommand cmdRetrieve = new SqlCommand(queryRetrieve, con))
                {
                    cmdRetrieve.Parameters.AddWithValue("@RegNo", textBox1.Text);

                    using (SqlDataReader reader = cmdRetrieve.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox2.Text = reader["FName"].ToString();
                            textBox3.Text = reader["LName"].ToString();
                            textBox4.Text = reader["RegNo"].ToString();
                            textBox5.Text = reader["Username"].ToString();
                            textBox6.Text = reader["Email"].ToString();
                            textBox7.Text = reader["YearOfStudy"].ToString();
                        }
                    }
                }
            }

            refreshdata();
        }

        private void ClearTextBoxes()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }


        private void button7_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Choose valid details to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
                string query = "UPDATE Students SET FName = @FName, LName = @LName WHERE RegNo = @RegNo";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RegNo", textBox1.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@FName", textBox2.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@LName", textBox3.Text.ToUpper());
                        //cmd.Parameters.AddWithValue("@RegNo", textBox4.Text);
                        //cmd.Parameters.AddWithValue("@Username", textBox5.Text.ToUpper());
                        //cmd.Parameters.AddWithValue("@Email", textBox6.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@YearOfStudy", textBox7.Text);



                        // Add other parameters as necessary

                        con.Open();
                        cmd.ExecuteNonQuery();
                        refreshdata();
                    }
                }

                MessageBox.Show("Data Updated successfully", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshdata();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Check if textBox1 is empty
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please choose a profile to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you Sure to Delete this Profile ", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Proceed with deletion if textBox1 is not empty
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string query = "DELETE FROM Students WHERE RegNo = @RegNo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RegNo", textBox1.Text);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

                MessageBox.Show("Data deleted successfully", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshdata();
            }
            else
            {
                MessageBox.Show("Deletion Cancelled ","Delete Status",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear(); 
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            refreshdata();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[2].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();
            textBox4.Text = selectedRow.Cells[0].Value.ToString();
            textBox5.Text = selectedRow.Cells[1].Value.ToString();
            textBox6.Text = selectedRow.Cells[7].Value.ToString();
            textBox7.Text = selectedRow.Cells[11].Value.ToString();
            refreshdata();
        }
    }
}

