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
    public partial class loanform : Form
    {
        public loanform()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LENOVO--PC;Initial catalog=jkbank;Integrated Security= True");
        private void lbtnnew_Click(object sender, EventArgs e)
        {
            loanform lf = new loanform();
            lf.Show();
            con.Open();
            SqlCommand cd = new SqlCommand("SELECT TOP 1 RIGHT(AccountNo,1)+2  From loanform order by 1 desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cd);
            object VALUE= da.SelectCommand.ExecuteScalar();
             VALUE = "accno:" + VALUE;
             accno.Text = VALUE.ToString();

            
        }

        private void sbtnsav_Click(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO loanform(AccountNo,Customername,Fathername,Gender,DOB,Address,Phoneno,Email,Occupation,Pincode,Branch,District,State,Country,Photoo,Signn,Namee,Father,Gaddress,Goccupation,Gphoneno,Loanamount,Loantype,Purpose,Period,Openingdate,Installamount,Gphoto,Gsign)Values('" + accno.Text + "','" + cname.Text + "','" + fnhn.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + add.Text + "','" + pno.Text + "','" + email.Text + "','" + occu.Text + "','" + pinc.Text + "','" + comboBox2.Text + "','" + dist.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + lpictureBox1 + "','" + lpictureBox2 + "','" + gname.Text + "','" + gfname.Text + "','" + gadd.Text + "','" + goccu.Text + "','" + gpno.Text + "','" + lnamt.Text + "','" + comboBox5.Text + "','" + prpos.Text + "','" + prd.Text + "','" + dateTimePicker2.Text + "','" + instamt.Text + "','" + lpictureBox3 + "','" + lpictureBox4 + "')", con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Saved successfully");

            }
            catch { MessageBox.Show("Fill the data correctly!!"); }

        }

        private void lbtnviw_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * FROM loanform", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void lbtnupgrade_Click(object sender, EventArgs e)
        {
            try
            {
             con.Open();
             SqlDataAdapter ad = new SqlDataAdapter("UPDATE loanform SET Customername='" + cname.Text + "',Fathername='" + fnhn.Text + "',Gender='" + comboBox1.Text + "',DOB='" + dateTimePicker1.Text + "',Address='" + add.Text + "',Phoneno='" + pno.Text + "',Email='" + email.Text + "',Occupation='" + occu.Text + "',Pincode='" + pinc.Text + "',Branch='" + comboBox2.Text + "',District='" + dist.Text + "',State='" + comboBox3.Text + "',Country='" + comboBox4.Text + "',Photoo='" + lpictureBox1 + "',Signn='" + lpictureBox2 + "',Namee='" + gname.Text + "',Father='" + gfname.Text + "',Gaddress='" + gadd.Text + "',Goccupation='" + goccu.Text + "',Gphoneno='" + gpno.Text + "',Loanamount='" + lnamt.Text + "',Loantype='" + comboBox5.Text + "',Purpose='" + prpos.Text + "',Period='" + prd.Text + "',Openingdate='" + dateTimePicker2.Text + "',Installamount='" + instamt.Text + "',Gphoto='" + lpictureBox3 + "',Gsign='" + lpictureBox4 + "'  WHERE Accountno='" + accno.Text + "'", con);
             ad.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Sucessfully");
         }
            catch { MessageBox.Show("Fill the data correctly!!"); }
        }

        private void lbtndel_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM loanform WHERE AccountNo='" + accno.Text + "'", con);
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Deleted Suessfully!");


        }

     

        private void lpictureBox1_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                lpictureBox1.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lpictureBox2_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                lpictureBox2.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lpictureBox3_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                lpictureBox3.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lpictureBox4_Click(object sender, EventArgs e)
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dgl = new OpenFileDialog();
                dgl.Filter = "jpg files(*,jpg|*,jpg|GIF Files(*.gif)|*.gif|ALL Files(*.*)|*.*";
                dgl.Title = "Select e picture";
                if (dgl.ShowDialog() == DialogResult.OK)
                    imgloc = dgl.FileName.ToString();
                lpictureBox4.ImageLocation = imgloc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      /*  private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }*/

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            accno.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            fnhn.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //    dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            add.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pno.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            email.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            occu.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            pinc.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            dist.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            gname.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
            gfname.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
            gadd.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
            goccu.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
            gpno.Text = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
            lnamt.Text = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
            prpos.Text = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();
            prd.Text = dataGridView1.SelectedRows[0].Cells[25].Value.ToString();
            instamt.Text = dataGridView1.SelectedRows[0].Cells[26].Value.ToString();
        }

        private void loanform_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

     

      
       
    }
}
