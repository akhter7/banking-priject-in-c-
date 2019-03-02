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
    public partial class fixedform : Form
    {
        public fixedform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");

        private void fbtnnew_Click(object sender, EventArgs e)
        {
            fixedform ff = new fixedform();
            ff.Show();
            con.Open();
            SqlCommand cd = new SqlCommand("SELECT TOP 1 RIGHT(AccountNo,1)+2  From fixedform order by 1 desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cd);
            object VALUE = cd.ExecuteScalar();
            VALUE = "accno:" + VALUE;
            faccno.Text = VALUE.ToString();
        }

        
        private void fbtnupdate_Click(object sender, EventArgs e)
        {
            try{
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE fixedform SET CustomerName='" + fcname.Text + "',Fathername='" + ffnhn.Text + "',Gender='" + fcomboBox1.Text + "',DOB='" + fdateTimePicker1.Text + "',Address='" + fadd.Text + "',Phoneno='" + fpno.Text + "',Email='" + femail.Text + "',Occupation='" + foccu.Text + "',Pincode='" + fpinc.Text + "',Branch='" + fcomboBox2.Text + "',District='" + fdist.Text + "',State='" + fcomboBox3.Text + "',Country='" + fcomboBox4.Text + "',Photo='" + fpictureBox1 + "',Sign='" + fpictureBox2 + "'WHERE AccountNo='" + faccno.Text + "'", con);
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully!");
             }
            catch { MessageBox.Show("Fill the data correctly!!"); }
        }

        private void fbtndel_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM fixedform WHERE AccountNo='" + faccno.Text + "'", con);
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully");
            
        }

        private void fdataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            faccno.Text = fdataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            fcname.Text = fdataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ffnhn.Text = fdataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            fcomboBox1.Text = fdataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //  fdateTimePicker1.Text = fdataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            fadd.Text = fdataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            fpno.Text = fdataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            femail.Text = fdataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            foccu.Text = fdataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            fpinc.Text = fdataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            fcomboBox2.Text = fdataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            fdist.Text = fdataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            fcomboBox3.Text = fdataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            fcomboBox4.Text = fdataGridView1.SelectedRows[0].Cells[13].Value.ToString();
        }

        private void fpictureBox1_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                fpictureBox1.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fpictureBox2_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                fpictureBox2.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fbtnsave_Click(object sender, EventArgs e)
        {
            try{
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("INSERT INTO fixedform (AccountNo,Customername,Fathername,Gender,DOB,Address,Phoneno,Email,Occupation,Pincode,Branch,District,State,Country,Photo,Sign)Values('" + faccno.Text + "','" + fcname.Text + "','" + ffnhn.Text + "','" + fcomboBox1.Text + "','" + fdateTimePicker1.Text + "','" + fadd.Text + "','" + fpno.Text + "','" + femail.Text + "','" + foccu.Text + "','" + fpinc.Text + "','" + fcomboBox2.Text + "','" + fdist.Text + "','" + fcomboBox3.Text + "','" + fcomboBox4.Text + "','" + fpictureBox1 + "','" + fpictureBox2 + "')", con);
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Form Saved Successfully");
                 }
            catch { MessageBox.Show("Fill the data correctly!!"); }
        }

        private void fbtnviw_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from fixedform", con);
            DataTable info = new DataTable();
            da.Fill(info);
            fdataGridView1.DataSource = info;
            con.Close();
        }

            
    }
}
