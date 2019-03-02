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

namespace bankproject
{
    public partial class balancesheet : Form
    {
        public balancesheet()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");
        private void ttbox_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "AccountNo")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT AccountNo,Customername,FathersName,Gender,DOB,Address,PhoneNo,Email,Occupation,PinCode,Branch,District,State,Country  FROM savingform1 WHERE AccountNo LIKE '" + ttbox.Text + "%'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;

                SqlDataAdapter sd1 = new SqlDataAdapter("SELECT Transaction_id,Date,Amount,Withdrawl,Avl_Balance  FROM transtab WHERE AccountNo LIKE '" + ttbox.Text + "%'", con);
                DataTable data1 = new DataTable();
                sd1.Fill(data1);
                dataGridView2.DataSource = data1;

                SqlDataAdapter sd2 = new SqlDataAdapter("SELECT transfer_id,Fromaccount,Toaccaount,date,TransferAmount  FROM transfer WHERE Fromaccount LIKE '" + ttbox.Text + "%'", con);
                DataTable data2 = new DataTable();
                sd2.Fill(data2);
                dataGridView3.DataSource = data2;
            }

            else if (comboBox1.Text == "CustomerName")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT AccountNo,Customername,FathersName,Gender,DOB,Address,PhoneNo,Email,Occupation,PinCode,Branch,District,State,Country,Accounthphoto,Accounthsigna  FROM savingform1 WHERE CustomerName LIKE '" + ttbox.Text + "%'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

         
    }
}
