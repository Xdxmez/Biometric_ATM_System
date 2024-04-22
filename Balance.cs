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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\BioDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum= '" +AccNumbertbl.Text+ "'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Balancetbl.Text = "RM "+dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void label11_Click(object sender, EventArgs e)
        {
            AccNumbertbl.Text = Home.AccNumber;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
            
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            AccNumbertbl.Text = Home.AccNumber;
            getbalance();
        }
    }
}
