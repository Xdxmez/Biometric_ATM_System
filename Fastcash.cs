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
    public partial class Fastcash : Form
    {
        public Fastcash()
        {
            InitializeComponent();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 300)
            {
                MessageBox.Show("Balance Cannot be Negative");
            }
            else
            {
                int newbalance = bal - 300;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newbalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    Home home = new Home();
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
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\BioDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum= '" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Balancetbl.Text = "Balance RM " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void Fastcash_Load(object sender, EventArgs e)
        {
            getbalance();
        }
       
       
            private void button1_Click(object sender, EventArgs e)
        {
            if(bal<100)
            {
                MessageBox.Show("Balance Cannot be Negative");
            }
            else
            {
               int newbalance = bal - 100;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newbalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Balance Cannot be Negative");
            }
            else
            {
                int newbalance = bal - 500;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newbalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 200)
            {
                MessageBox.Show("Balance Cannot be Negative");
            }
            else
            {
                int newbalance = bal - 200;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newbalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance Cannot be Negative");
            }
            else
            {
                int newbalance = bal - 1000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newbalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Balance Cannot be Negative");
            }
            else
            {
                int newbalance = bal - 2000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newbalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
