using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankproject
{
    public partial class Loginpage : Form
    {
        public Loginpage()
        {
            InitializeComponent();
        }
      

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "akhter" & textBox2.Text == "123")
            {
               jkbank mf = new jkbank();
               mf.Show();
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill all the fields ");
            }
            else
            {
                MessageBox.Show("Username or Password is Incorrect");
            }


        }

        private void Loginpage_FormClosed(object sender, FormClosedEventArgs e)
        {
              Application.Exit();
        }

       private void Loginpage_Load(object sender, EventArgs e)
        {

        }
    }
}
