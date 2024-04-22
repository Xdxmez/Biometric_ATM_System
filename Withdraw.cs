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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\BioDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum= '" +Acc+ "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Balancetbl.Text = "Balance RM " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void addtransaction()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + wdamtTb.Text + ",'" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Account created successfully");
                Con.Close();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        int newbalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if(wdamtTb.Text =="")
            {
                MessageBox.Show("Missing Information");
            }
            else if( Convert.ToInt32(wdamtTb.Text) == 0 )
            {
                MessageBox.Show("Enter a Valid Amount");
            }
            else if( Convert.ToInt32(wdamtTb.Text) > bal )
            {
                MessageBox.Show("Balance Cannot be Negative");
            }
            else
            {
                try
                {
                    newbalance = bal - Convert.ToInt32(wdamtTb.Text);
                    try
                    {
                        Con.Open();
                        string query = "update AccountTbl set Balance=" + newbalance + " where AccNum='" + Acc + "'";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success Withdraw");
                        Con.Close();
                        addtransaction();
                        Home home = new Home();
                        home.Show();
                        this.Hide();

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);    
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show() ;
        }
    }
}
