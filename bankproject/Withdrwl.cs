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
    public partial class Withdrwl : Form
    {
        public Withdrwl()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int acc = int.Parse(dacc.Text);

                con.Open();
                SqlCommand cm = new SqlCommand("select * from savingform1 where AccountNo='" + acc + "'", con);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {

                    dbal.Text = dr.GetValue(1).ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int check = 0;

                con.Open();
                SqlCommand cmd = new SqlCommand("select balance from savingform1 where AccountNo ='" + dacc.Text + "'", con);
                SqlDataReader DR1 = cmd.ExecuteReader();
                if (DR1.Read())
                {

                    check = int.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();
                int amount = int.Parse(amt.Text);
                if (check > 0 && check > amount)
                {


                    con.Open();

                    SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO transtab(AccountNo,Date,withdrawl,Avl_Balance)Values('" + dacc.Text + "','" + dateTimePicker2.Text + "','" + amt.Text + "','" + dbal.Text + "')", con);
                    SDA.SelectCommand.ExecuteNonQuery();

                    SqlDataAdapter SD = new SqlDataAdapter("update savingform1 set balance = balance -'" + amount + "' where AccountNo = '" + dacc.Text + "'", con);
                    SD.SelectCommand.ExecuteNonQuery();


                    con.Close();
                    MessageBox.Show("transaction Successful");
                }
                else
                {
                    MessageBox.Show("Balance available is only   " + check, "jkbank");
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
