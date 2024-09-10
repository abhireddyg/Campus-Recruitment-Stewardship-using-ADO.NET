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
    public partial class Form22 : Form
    {

        SqlConnection con =new SqlConnection( "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public Form22()
        {
            InitializeComponent();
            LoadApplications();
           // refreshdata();
        }

        private void LoadApplications()
        {

            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string query = "SELECT RegNo, FName, LName, Email, CCode, PERCENTAGE, RoleId, Comp, Role, Type, Skill, Salary FROM Application WHERE Comp = (SELECT CompName from Company where UserId = @Username) ";
            //string query = "SELECT * FROM Application WHERE Comp = (select CompName from Company where UserId = @Username)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Form6.comp); // Assuming Form3.x contains the username value
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();


        }

        /*private void refreshdata()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM APPLICATION where Comp = (select CompName from Company where UserId = ''' + Form6.comp + ''' ) ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        */
        private void Form22_Load(object sender, EventArgs e)
        {

            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.applicationTableAdapter.FillBy(this.cRS1DataSet5.Application);
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
                this.applicationTableAdapter.FillBy1(this.cRS1DataSet5.Application);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20();
            form20.ShowDialog();
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

        private void button8_Click(object sender, EventArgs e)
        {
            bool isAnyChecked = false;

            // Loop through DataGridView rows to check if any checkbox is checked
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Column1"].Value != null && Convert.ToBoolean(row.Cells["Column1"].Value))
                {
                    isAnyChecked = true;
                    break;
                }
            }

            // If no checkbox is checked, show a message and exit
            if (!isAnyChecked)
            {
                MessageBox.Show("Select Atleast One application to Hire", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False"))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Column1"].Value != null && Convert.ToBoolean(row.Cells["Column1"].Value))
                        {
                            // Retrieve values from DataGridView row
                            string regNo = row.Cells["RegNo"].Value.ToString();
                            // string fName = row.Cells["FName"].Value.ToString();
                            string fName = "Abhi";
                            string lName = row.Cells["LName"].Value.ToString();
                            string email = row.Cells["Email"].Value.ToString();
                            string cCode = row.Cells["CCode"].Value.ToString();
                            string percentage = row.Cells["Percentage"].Value.ToString();
                            string roleId = row.Cells["RoleId"].Value.ToString();
                            string comp = row.Cells["Comp"].Value.ToString();
                            string role = row.Cells["Role"].Value.ToString();
                            string type = row.Cells["Type"].Value.ToString();
                            string skill = row.Cells["Skill"].Value.ToString();
                            string salary = row.Cells["Salary"].Value.ToString();

                            // Insert the selected applicant into the Hired table
                            string insertQuery = "INSERT INTO Hired (RegNo, FName, LName, Email, CCode, Percentage, RoleId, Comp, Role, Type, Skill, Salary) VALUES (@RegNo, @FName, @LName, @Email, @CCode, @Percentage, @RoleId, @Comp, @Role, @Type, @Skill, @Salary)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@RegNo", regNo);
                                insertCmd.Parameters.AddWithValue("@FName", fName);
                                insertCmd.Parameters.AddWithValue("@LName", lName);
                                insertCmd.Parameters.AddWithValue("@Email", email);
                                insertCmd.Parameters.AddWithValue("@CCode", cCode);
                                insertCmd.Parameters.AddWithValue("@Percentage", percentage);
                                insertCmd.Parameters.AddWithValue("@RoleId", roleId);
                                insertCmd.Parameters.AddWithValue("@Comp", comp);
                                insertCmd.Parameters.AddWithValue("@Role", role);
                                insertCmd.Parameters.AddWithValue("@Type", type);
                                insertCmd.Parameters.AddWithValue("@Skill", skill);
                                insertCmd.Parameters.AddWithValue("@Salary", salary);
                                insertCmd.ExecuteNonQuery();
                            }

                            // Delete the selected applicant from the Application table
                            string deleteQuery = "DELETE FROM Application WHERE RegNo = @RegNo AND RoleId = @RoleId";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@RegNo", regNo);
                                deleteCmd.Parameters.AddWithValue("@RoleId", roleId);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Successfully Hired the Selected Applicants", "Hire Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refreshdata(); // Refresh the data to reflect the changes
                    LoadApplications();
                }
            }
        }


        private void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from application where RegNo= @RegNo and RoleId = @RoleId",conn);
            cmd.Parameters.AddWithValue("@RegNo",textBox1.Text);
            cmd.Parameters.AddWithValue("RoleId",textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("You Rejected the Selected Applicants", "Hire Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

            clear();
            LoadApplications();
            //refreshdata();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[7].Value.ToString();

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.applicationTableAdapter.FillBy2(this.cRS1DataSet5.Application);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy2ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //refreshdata();
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("No Applications Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadApplications();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
