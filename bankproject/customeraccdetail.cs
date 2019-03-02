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
    public partial class customeraccdetail : Form
    {
        public customeraccdetail()
        {
            InitializeComponent();
        }
     SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");

        private void tbox_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "AccountNo")
            { 
              SqlDataAdapter sda = new SqlDataAdapter("SELECT AccountNo,Customername,FathersName,Gender,DOB,Address,PhoneNo,Email,Occupation,PinCode,Branch,District,State,Country,Accounthphoto,Accounthsigna  FROM savingform1 WHERE AccountNo LIKE '" +tbox.Text + "%'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
             }
        }

      
    }
}
