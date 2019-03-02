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
    public partial class currentform : Form
    {
        public currentform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");
        
        private void cbtnnew_Click(object sender, EventArgs e)
        {   currentform cf=new currentform();
            cf.Show();
            con.Open();
            SqlCommand cd = new SqlCommand("SELECT TOP 1 RIGHT(AccountNo,1)+2  From cuform order by 1 desc", con);
            SqlDataAdapter da= new SqlDataAdapter(cd);
            object VALUE = cd.ExecuteScalar();
            VALUE = "accno" + VALUE;
            caccno.Text = VALUE.ToString();
        }

        private void cbtnsav_Click(object sender, EventArgs e)
        { 
           try
            {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("INSERT INTO cuform (AccountNo,Customername,Fathername,Gender,DOB,Address,Phoneno,Email,Occupation,Pincode,Branch,District,State,Country,Photo,Sign)Values('" + caccno.Text + "','" + ccname.Text + "','" + cfnhn.Text + "','" + ccomboBox1.Text + "','" + cdateTimePicker1.Text + "','" + cadd.Text + "','" + cpno.Text + "','" + cemail.Text + "','" + coccu.Text + "','" + cpinc.Text + "','" + ccomboBox2.Text + "','" + cdist.Text + "','" + ccomboBox3.Text + "','" + ccomboBox4.Text + "','" + cpictureBox1 + "','" + cpictureBox2 + "')", con);
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Form Saved Successfully");
            }
          catch { MessageBox.Show("Fill the data correctly!!"); }

        }

        private void cbtnview_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select AccountNo,Customername,Fathername,Gender,DOB,Address,PhoneNo,Email,Occupation,PinCode,Branch,District,State,Country from cuform", con);
            DataTable info = new DataTable();
            da.Fill(info);
            cdataGridView1.DataSource = info;
            con.Close();

        }

        private void cbtnupdate_Click(object sender, EventArgs e)
        { 
            try
             {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE cuform SET CustomerName='" + ccname.Text + "',Fathername='" + cfnhn.Text + "',Gender='" + ccomboBox1.Text + "',DOB='" + cdateTimePicker1.Text + "',Address='" + cadd.Text + "',Phoneno='" + cpno.Text + "',Email='" + cemail.Text + "',Occupation='" + coccu.Text + "',Pincode='" + cpinc.Text + "',Branch='" + ccomboBox2.Text + "',District='" + cdist.Text + "',State='" + ccomboBox3.Text + "',Country='" + ccomboBox4.Text + "',Photo='" + cpictureBox1 + "',Sign='" + cpictureBox2 + "'WHERE AccountNo='" + caccno.Text + "'", con);
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully!");
             }
            catch { MessageBox.Show("Fill the data correctly!!"); }
        }

        private void cbtndel_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM cuform WHERE AccountNo='" + caccno.Text + "'", con);
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully");
            
        }

        private void cdataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             caccno.Text = cdataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ccname.Text = cdataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cfnhn.Text = cdataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ccomboBox1.Text = cdataGridView1.SelectedRows[0].Cells[3].Value.ToString();
          //  cdateTimePicker1.Text = cdataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            cadd.Text = cdataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            cpno.Text = cdataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cemail.Text = cdataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            coccu.Text = cdataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            cpinc.Text = cdataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            ccomboBox2.Text = cdataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            cdist.Text = cdataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            ccomboBox3.Text = cdataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            ccomboBox4.Text = cdataGridView1.SelectedRows[0].Cells[13].Value.ToString();
        }

        private void cpictureBox1_Click(object sender, EventArgs e)
        {
             
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                cpictureBox1.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cpictureBox2_Click(object sender, EventArgs e)
        {
           
            
                string imgloc = "";
                try
                {
                    OpenFileDialog dgl = new OpenFileDialog();
                    dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                    dgl.Title = "Select e picture";
                    if (dgl.ShowDialog() == DialogResult.OK)
                        imgloc = dgl.FileName.ToString();
                    cpictureBox2.ImageLocation = imgloc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            

           
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }


  
    }
}
