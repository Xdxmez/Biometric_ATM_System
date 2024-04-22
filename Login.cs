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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Account acc =new Account();
            acc.Show();
            this.Hide();
        }
        public static String AccNumber;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\BioDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (AccNumTb.Text == "admin" && PinTb.Text == "0000")
            {
                Admin admin = new Admin();
                admin.Show();
            }else
            {
                try
                {

                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTbl where AccNum = '" + AccNumTb.Text + "' and Pin = " + PinTb.Text, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            if (dt.Rows[0][0].ToString() == "1" )
            {
                AccNumber = AccNumTb.Text;
                Home home = new Home();
                home.Show();
                this.Hide();
                Con.Close();

            }else
            {
                MessageBox.Show("Wrong Account number or PIN Code");
            }
            Con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
