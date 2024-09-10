using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CRS_ADO_N
{
    public partial class Form21 : Form
    {
        public int SearchID { get; set; } // ID from Form20

        public Form21()
        {
            InitializeComponent();
            LoadTPOs();
        }

        private void LoadTPOs()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "SELECT InstCode, FName FROM TPO"; // Replace with your actual table and column names

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                        /* Add a CheckBox column
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.HeaderText = "Select";
                        checkBoxColumn.Name = "Select";
                        dataGridView1.Columns.Insert(0, checkBoxColumn);
                        */
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Form21_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cRS1DataSet.TPO' table. You can move, or remove it, as needed.
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
            //this.tPOTableAdapter.Fill(this.cRS1DataSet.TPO);

        }
        public static string cCode;
        private void button8_Click(object sender, EventArgs e)
        {


            bool isAnyChecked = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Column1"].Value);
                if (isChecked)
                {
                    isAnyChecked = true;
                    //cCode = row.Cells["InstCode"].Value.ToString();
                    break; // No need to check further, as we found a checked checkbox
                }
            }

            if (isAnyChecked)
            {
                MessageBox.Show("Notification sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form19 f = new Form19();
                f.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Select at least one TPO.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            /*string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open ();
                SqlCommand cmd = new SqlCommand("Insert into CompToTpo");


                MessageBox.Show("Notificationn Successfully Sent ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);


                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO CompToTPO (ID, FName,CompName, Type,Role,Skill, Salary, InstCode) VALUES (@ID, @FName,@CompName,@Type,@Role,@Skill, @Salary, @InstCode)";

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["Column1"].Value != null && (bool)row.Cells["Column1"].Value)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ID", SearchID);
                                cmd.Parameters.AddWithValue("@FName", row.Cells["FName"].Value.ToString());
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Records added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
