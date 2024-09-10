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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            this.Hide();
        }
        public static string x;
        private void button1_Click(object sender, EventArgs e)
        {
            x = textBox1.Text;

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sai chowdry\\OneDrive\\Documents\\CRS1.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Students where Username = @Username and  Pass = @Pass", con);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Pass", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);  
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
            {
                Form8 form = new Form8();
                MessageBox.Show("Login Successful..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox2.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
