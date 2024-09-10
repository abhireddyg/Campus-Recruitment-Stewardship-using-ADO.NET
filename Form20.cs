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
    public partial class Form20 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");

        private void refereshdata()
        {

            SqlCommand cmd = new SqlCommand("SELECT * from Jobs where CompName = @CompName", conn);
            cmd.Parameters.AddWithValue("@CompName", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        public Form20()
        {
            InitializeComponent();
            LoadJobs();
            refereshdata();
        }
        public static string x;
        private void Form20_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
            LoadJobs();
            refereshdata();


            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT CompName FROM Company WHERE UserId = @UserId";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", Form6.comp);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string x = reader["CompName"].ToString().ToUpper();
                        textBox2.Text = x;
                    }

                }
            }
        }

        private void LoadJobs()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT Id,Type,Role,Skill,Salary from Jobs where CompName = ''' + textBox2.Text + ''' ";

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

        private void button7_Click(object sender, EventArgs e)
        {
            refereshdata();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            string query = "SELECT * FROM Jobs WHERE ID = @ID  ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", textBox1.Text);

                        if (string.IsNullOrEmpty(textBox1.Text))
                        {
                            MessageBox.Show("Enter Valid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearTextBoxes();
                            return;
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox2.Text = reader["CompName"].ToString();
                                textBox3.Text = reader["ID"].ToString();
                                textBox4.Text = reader["Type"].ToString();
                                textBox5.Text = reader["Role"].ToString();
                                textBox6.Text = reader["Skill"].ToString();
                                textBox7.Text = reader["Salary"].ToString();
                                refereshdata();
                            }
                            else
                            {
                                MessageBox.Show("ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearTextBoxes();
                            }
                        }
                        refereshdata();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }



        private void button9_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Check if any of the required textboxes are empty
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Please fill out all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Jobs WHERE ID = @ID", conn);
                    checkCmd.Parameters.AddWithValue("@ID", textBox3.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID " + textBox3.Text + " already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // Insert the new job and get the generated ID
                        string query = "INSERT INTO Jobs (CompName, ID, Type, Role, Skill, Salary) VALUES (@CompName, @ID, @Type, @Role, @Skill, @Salary)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CompName", textBox2.Text);
                            cmd.Parameters.AddWithValue("@ID", textBox3.Text);
                            cmd.Parameters.AddWithValue("@Type", textBox4.Text);
                            cmd.Parameters.AddWithValue("@Role", textBox5.Text);
                            cmd.Parameters.AddWithValue("@Skill", textBox6.Text);
                            cmd.Parameters.AddWithValue("@Salary", int.Parse(textBox7.Text));

                            cmd.ExecuteNonQuery();
                            refereshdata();

                            MessageBox.Show("Job Role Inserted", "Vacancy Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to delete this opportunity?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                MessageBox.Show("Deletion Cancelled","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Check if the ID exists
                        string checkQuery = "SELECT COUNT(*) FROM Jobs WHERE ID = @ID";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@ID", textBox1.Text);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                // ID exists, delete the record
                                string deleteQuery = "DELETE FROM Jobs WHERE ID = @ID";
                                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                                {
                                    deleteCmd.Parameters.AddWithValue("@ID", textBox1.Text);
                                    deleteCmd.ExecuteNonQuery();

                                    MessageBox.Show("Record with ID " + textBox1.Text + " deleted successfully.", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearTextBoxes();
                                    textBox2.Text = x;
                                }
                            }
                            else
                            {
                                // ID does not exist
                                MessageBox.Show("Enter Valid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearTextBoxes();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            refereshdata();
            LoadJobs();

        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            //textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if the ID exists
                    string checkQuery = "SELECT COUNT(*) FROM Jobs WHERE ID = @ID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", textBox1.Text);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // ID exists, update the record
                            string updateQuery = "UPDATE Jobs SET CompName = @CompName, Type = @Type, Role = @Role, Skill = @Skill, Salary = @Salary WHERE ID = @ID";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@CompName", textBox2.Text);
                                updateCmd.Parameters.AddWithValue("@Type", textBox4.Text);
                                updateCmd.Parameters.AddWithValue("@Role", textBox5.Text);
                                updateCmd.Parameters.AddWithValue("@Skill", textBox6.Text);
                                updateCmd.Parameters.AddWithValue("@Salary", int.Parse(textBox7.Text));
                                updateCmd.Parameters.AddWithValue("@ID", textBox1.Text);

                                updateCmd.ExecuteNonQuery();
                                MessageBox.Show("Record updated successfully.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refereshdata();
                            }
                        }
                        else
                        {
                            // ID does not exist
                            MessageBox.Show("Enter Valid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearTextBoxes();
                        }
                    }
                    refereshdata();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox3.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox4.Text = selectedRow.Cells[2].Value.ToString();
            textBox5.Text = selectedRow.Cells[3].Value.ToString();
            textBox6.Text = selectedRow.Cells[4].Value.ToString();
            textBox7.Text = selectedRow.Cells[5].Value.ToString();
        }

        public static string id;
        private void button11_Click_1(object sender, EventArgs e)
        {
            id = textBox1.Text;
            Form21 f = new Form21();
            f.ShowDialog();
            this.Hide();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button5.BackColor = SystemColors.HotTrack;
                button5.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("You Logged Out Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form6 f = new Form6();
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

        private void button12_Click(object sender, EventArgs e)
        {
            refereshdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form23 f = new Form23();
            f.ShowDialog();
            this.Hide();
        }
    }
}