using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CRS_ADO_N
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            LoadJobs();
            refereshdata();
        }

        private void LoadJobs()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "SELECT * from Jobs ";

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

        private void refereshdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Jobs", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void studentBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void studentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.ShowDialog();
            this.Hide();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cRS1DataSet3.Jobs' table. You can move, or remove it, as needed.


            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
            //this.jobsTableAdapter.Fill(this.cRS1DataSet3.Jobs);
            button3.BackColor = SystemColors.HotTrack;
            button3.ForeColor = SystemColors.ButtonHighlight;


        }

        private void button3_Click(object sender, EventArgs e)
        {


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
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            button5.BackColor = SystemColors.HotTrack;
            button5.ForeColor = SystemColors.ButtonHighlight;
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
                button5.BackColor = SystemColors.HotTrack;
                button5.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.ShowDialog();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.ShowDialog();
            this.Hide();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 28);

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 23);

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

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.FontFamily, 28);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.FontFamily, 23);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //refereshdata();
            MessageBox.Show("Opportunities Data Refreshed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            textBox2.Text = selectedRow.Cells[2].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();
            textBox4.Text = selectedRow.Cells[4].Value.ToString();
            textBox5.Text = selectedRow.Cells[5].Value.ToString();
            textBox6.Text = selectedRow.Cells[0].Value.ToString();
            //textBox7.Text = selectedRow.Cells[10].Value.ToString();
            refereshdata();

        }

        // Method to get student data
        private DataTable GetStudentData(string a)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "SELECT FName, LName, Email, RegNo,PERCENTAGE,CCode FROM Students where Username = @Username";
            DataTable studentData = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", Form3.x);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(studentData);
                }
            }

            return studentData;
        }

        // Method to check if the student has already applied for the role
        private bool HasStudentAlreadyApplied(string regNo, string roleId)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "SELECT COUNT(*) FROM StudApplied WHERE RegNo = @RegNo AND RId = @RoleId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RegNo", regNo);
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Method to insert data into Application table
        private void InsertIntoApplication(DataRow studentRow)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "INSERT INTO Application (RegNo, FName, LName, Email, CCode,PERCENTAGE, RoleId, Comp, Type, Role, Skill, Salary) VALUES (@RegNo, @FName, @LName, @Email, @CCode, @PERCENTAGE,@RoleId, @Comp, @Type, @Role, @Skill, @Salary)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RegNo", studentRow["RegNo"]);
                    cmd.Parameters.AddWithValue("@FName", studentRow["FName"]);
                    cmd.Parameters.AddWithValue("@LName", studentRow["LName"]);
                    cmd.Parameters.AddWithValue("@Email", studentRow["Email"]);
                    cmd.Parameters.AddWithValue("@CCode", studentRow["CCode"]);
                    cmd.Parameters.AddWithValue("@PERCENTAGE", studentRow["Percentage"]);
                    cmd.Parameters.AddWithValue("@RoleId", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Comp", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Type", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Role", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Skill", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Salary", textBox5.Text);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to insert data into StuApplied table
        private void InsertIntoStuApplied(DataRow studentRow)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "INSERT INTO StudApplied (RegNo, RId, Comp, Type, Role, Skill, Salary) VALUES (@RegNo, @RId, @Comp, @Type, @Role, @Skill, @Salary)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RegNo", studentRow["RegNo"]);
                    cmd.Parameters.AddWithValue("@RId", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Comp", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Type", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Role", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Skill", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Salary", textBox5.Text);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string confirmationMessage = $"Do you want to apply to {textBox1.Text} for the {textBox4.Text} {textBox3.Text} role?";
            DialogResult result = MessageBox.Show(confirmationMessage, "Apply Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string a = Form3.x;

            if (result == DialogResult.Yes)
            {
                DataTable studentData = GetStudentData(a);

                if (studentData.Rows.Count == 0)
                {
                    MessageBox.Show("Student data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow studentRow = studentData.Rows[0];

                if (HasStudentAlreadyApplied(studentRow["RegNo"].ToString(), textBox6.Text))
                {
                    MessageBox.Show("Already Applied For this Role.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InsertIntoApplication(studentRow);
                    InsertIntoStuApplied(studentRow);
                    MessageBox.Show("Application submitted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
