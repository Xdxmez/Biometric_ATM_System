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

namespace BiometricATM
{
    public partial class ChangePIN : Form
    {
        public ChangePIN()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\BioDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Pin1Tb.Text == "" || Pin2Tb.Text == "")
            {
                MessageBox.Show("Enter and Confirm the new PIN");
            }
            else if(Pin2Tb.Text != Pin1Tb.Text)
            {
                MessageBox.Show("Pin1 And Pin2 are Different");
            }
            else
            {

               
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set PIN=" + Pin1Tb.Text + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN Successfully Updated");
                    Con.Close();
                    Login home = new Login();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
