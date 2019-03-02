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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");

  
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                int check = 0;

                con.Open();
                SqlCommand cmd = new SqlCommand("select balance from savingform1 where AccountNo ='" + fno.Text + "'", con);
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
                        SqlTransaction trn = con.BeginTransaction();
                     try
                        {
                        SqlCommand cm = new SqlCommand("INSERT INTO transfer(Fromaccount,Toaccaount,transferamount,date)Values('" + fno.Text + "','" + tno.Text + "','" + amt.Text + "','" + dateTimePicker2.Text + "')", con, trn);
                        cm.ExecuteNonQuery();

                        SqlCommand cm1 = new SqlCommand("update savingform1 set balance = balance -'" + amount + "' where Accountno = '" + fno.Text + "'", con,trn);
                        cm.ExecuteNonQuery();

                        SqlCommand cm2 = new SqlCommand("update savingform1 set balance = balance +'" + amount + "' where  Accountno = '" + tno.Text + "'", con,trn);
                        cm.ExecuteNonQuery();

                        trn.Commit();
                        con.Close();
                        MessageBox.Show("Transfered  Successfully");
                    }
                    catch (Exception exe) {
                        trn.Rollback();
                        MessageBox.Show(exe.Message); }

                }

                else
                {
                    MessageBox.Show("BAkance available is only " + check, "jkbank");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            }
      }
    }

