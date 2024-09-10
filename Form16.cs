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
    public partial class Form16 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public Form16()
        {
            InitializeComponent();
            LoadApplications();
            refreshdata();
        }



        private void LoadApplications()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "SELECT a.* FROM Application a INNER JOIN TPO t ON a.CCode = t.InstCode";

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

        private void refreshdata()
        {

            SqlCommand cmd = new SqlCommand("SELECT a.* FROM Application a INNER JOIN TPO t ON a.CCode = t.InstCode", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void Form16_Load(object sender, EventArgs e)
        {

            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);

            // TODO: This line of code loads data into the 'cRS1DataSet6.Application' table. You can move, or remove it, as needed.
          //  this.applicationTableAdapter.Fill(this.cRS1DataSet6.Application);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();
            f.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            f.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 f = new Form15();
            f.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button6.BackColor = SystemColors.HotTrack;
                button6.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("You Logged Out Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TPOLogin f = new TPOLogin();
                f.ShowDialog();
                this.Hide();
            }
            else
            {

                button6.BackColor = SystemColors.MenuHighlight;
                button6.ForeColor = SystemColors.ControlText;
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form16_Load_1(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.applicationTableAdapter.FillBy(this.cRS1DataSet6.Application);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("No Applications available to Forward", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Student Applicatoins Forwarded to Company", "Student Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form12 f = new Form12();
                f.ShowDialog();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            refreshdata();
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("No Applications recieved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Data Refreshed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.ShowDialog();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.ShowDialog();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
            form15.ShowDialog();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button6.BackColor = SystemColors.HotTrack;
                button6.ForeColor = SystemColors.ButtonHighlight;
                MessageBox.Show("You Logged Out Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TPOLogin f = new TPOLogin();
                f.ShowDialog();
                this.Hide();
            }
            else
            {

                button6.BackColor = SystemColors.MenuHighlight;
                button6.ForeColor = SystemColors.ControlText;
                MessageBox.Show("Logout Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
