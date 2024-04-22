using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BiometricATM
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\BioDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNameTb.Text == "" || AccNumTb.Text == "" || FaNameTb.Text == "" || PhoneTb.Text == "" || addressTb.Text == "" || OccupationTb.Text == "" || PinTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccountTbl values('" + AccNumTb.Text + "','" + AccNameTb.Text + "','" + FaNameTb.Text + "','" + DobDate.Value.Date + "','" + PhoneTb.Text + "','" + addressTb.Text + "','" + EducationTb.SelectedItem.ToString() + "','" + OccupationTb.Text + "','" + PinTb.Text + "',"+bal+")";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
