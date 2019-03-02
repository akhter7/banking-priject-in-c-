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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                long acc = long.Parse(dacc.Text);
                con.Open();
                SqlCommand cm = new SqlCommand("select * from savingform1 where AccountNo ='" + acc + "'", con);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    dbal.Text = dr.GetValue(1).ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                long deposit = long.Parse(amt.Text);

                con.Open();

                SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO transtab(AccountNo,Date,Amount,Avl_Balance)Values('" + dacc.Text + "','" + dateTimePicker2.Text + "','" + amt.Text + "','" + dbal.Text + "')", con);
                SDA.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter SD = new SqlDataAdapter("update savingform1 set balance = balance +'" + deposit + "' where AccountNo = '" + dacc.Text + "'", con);
                SD.SelectCommand.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Deposited Successfully");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

       
    }
}
