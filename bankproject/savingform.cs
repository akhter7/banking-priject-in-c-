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
    public partial class savingform : Form
    {
        public savingform()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");
        private void btnnew_Click(object sender, EventArgs e)
        {

            savingform sf = new savingform();
            sf.Show();
            con.Open();
            SqlCommand cd = new SqlCommand("SELECT TOP 1 RIGHT(AccountNo,1)+2  From savingform1 order by 1 desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cd);
            object VALUE = cd.ExecuteScalar();
            VALUE = "accno:" + VALUE;
            accno.Text = VALUE.ToString();


        }

        private void btnsav_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO savingform1(balance,Customername,FathersName,Gender,DOB,Address,PhoneNo,Email,Occupation,PinCode,Branch,District,State,Country,Accounthphoto,Accounthsigna)Values('" + textBox1.Text + "','" + cname.Text + "','" + fnhn.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + add.Text + "','" + pno.Text + "','" + email.Text + "','" + occu.Text + "','" + pinc.Text + "','" + comboBox2.Text + "','" + dist.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + pictureBox1 + "','" + pictureBox2 + "')", con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved Successfully");
            }
            catch { MessageBox.Show("Fill the the data correctly!!"); }

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Accountno,balance,Customername,FathersName,Gender,DOB,Address,PhoneNo,Email,Occupation,PinCode,Branch,District,State,Country FROM savingform1", con);
            DataTable data = new DataTable();
            da.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("UPDATE savingform1 SET CustomerName='" + cname.Text + "',FathersName='" + fnhn.Text + "',Gender='" + comboBox1.Text + "',DOB='" + dateTimePicker1.Text + "',Address='" + add.Text + "',PhoneNo='" + pno.Text + "',Email='" + email.Text + "',Occupation='" + occu.Text + "',Pincode='" + pinc.Text + "',Branch='" + comboBox2.Text + "',District='" + dist.Text + "',State='" + comboBox3.Text + "',Country='" + comboBox4.Text + "',AccounthPhoto='" + pictureBox1 + "',Accounthsigna='" + pictureBox2 + "'WHERE AccountNo='" + accno.Text + "'", con);
                ad.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Sucessfully");
            }
            catch { MessageBox.Show("Fill the data correctly!!"); }
        }

        private void Btndel_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter ada = new SqlDataAdapter("DELETE FROM savingform1 WHERE AccountNo='" + accno.Text + "'", con);
            ada.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Deleted Suessfully!");

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {   
            accno.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            fnhn.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
      //    dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            add.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pno.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            email.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            occu.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            pinc.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            dist.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                pictureBox1.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                pictureBox2.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void savingform_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select MAX(AccountNo) from savingform1", con);
            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                long acno = long.Parse(DR1.GetValue(0).ToString());
                ++acno;
                accno.Text = acno.ToString();
            }
            con.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    
    }
}