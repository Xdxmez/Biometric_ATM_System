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
    public partial class Ministatement : Form
    {
        public Ministatement()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\BioDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        private void populate()
        {
            Con.Open();
            string query = "select * from TransactionTbl where AccNum='" + Acc + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MinistatementDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Ministatement_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void MinistatementDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
