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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            LoadMyApps();
            //refereshdata(); 
        }


        /*
        private void refereshdata()
        { 
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
//            SqlCommand cmd = new SqlCommand("SELECT * FROM StudApplied WHERE RegNo = (SELECT RegNo FROM Students WHERE Username = ''' + Form3.x +''')", conn);

            SqlCommand cmd = new SqlCommand("SELECT * FROM StudApplied WHERE RegNo = (SELECT RegNo FROM Students WHERE Username = ''' + Form3.x +''')",conn    );
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }*/


        private void LoadMyApps()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string query = "SELECT * FROM StudApplied WHERE RegNo = (SELECT RegNo FROM Students WHERE Username = @Username)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Form3.x); // Assuming Form3.x contains the username value

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            button6.BackColor = SystemColors.HotTrack;
            button6.ForeColor = SystemColors.ButtonHighlight;

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
                button6.BackColor = SystemColors.MenuHighlight;
                button6.ForeColor = SystemColors.ControlText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

            button1.Font = new Font(button1.Font.FontFamily, 26);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font.FontFamily, 23);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.FontFamily, 26);

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font.FontFamily, 23);

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.FontFamily, 26);

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font.FontFamily, 23);

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Font = new Font(button6.Font.FontFamily, 26);

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Font = new Font(button6.Font.FontFamily, 23);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studAppliedTableAdapter.FillBy(this.cRS1DataSet7.StudApplied);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //refereshdata();
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("You haven't applied any Job Opportunities yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadMyApps();
                //refereshdata();
            }
        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.applicationTableAdapter.FillBy(this.cRS1DataSet9.Application);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studAppliedTableAdapter.FillBy1(this.cRS1DataSet7.StudApplied);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[4].Value.ToString();
            textBox5.Text = selectedRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if textBox1 is empty
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Choose an application to view the status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string regNo = textBox1.Text; // Assuming textBox1 contains the RegNo
            string roleId = textBox2.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check in Hired Table
                string queryHired = "SELECT Comp, Skill, Role FROM Hired WHERE RegNo = @RegNo AND RoleId = @RoleId";
                using (SqlCommand cmd = new SqlCommand(queryHired, conn))
                {
                    cmd.Parameters.AddWithValue("@RegNo", regNo);
                    cmd.Parameters.AddWithValue("@RoleId", roleId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string company = reader["Comp"].ToString();
                            string skill = reader["Skill"].ToString();
                            string role = reader["Role"].ToString();
                            textBox6.Text = $@"Congratulations! 
    You are hired in {company.ToUpper()} as a {skill.ToUpper()} {role.ToUpper()}";
                            return;
                        }
                    }
                }

                // Check in Application Table
                string queryApplication = "SELECT * FROM Application WHERE RegNo = @RegNo AND RoleId = @RoleId";
                using (SqlCommand cmd = new SqlCommand(queryApplication, conn))
                {
                    cmd.Parameters.AddWithValue("@RegNo", regNo);
                    cmd.Parameters.AddWithValue("@RoleId", roleId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox6.Text = "Your Application is still in Pending State";
                            return;
                        }
                    }
                }

                // If not in both tables
                textBox6.Text = "Better Luck Next Time. You are Not Selected.";
            }
        }

        private void button7_Click(object sender, EventArgs e)
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
