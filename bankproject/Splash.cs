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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
                timer1.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { }

       
        Timer t;
        private void splash_Shown(object sender, EventArgs e)
        {
            t = new Timer();
          t.Interval = 5000;
          t.Start();
          t.Tick +=t_Tick;


        }

        void t_Tick(object sender, EventArgs e)
        {
            t.Stop();
           Loginpage f = new Loginpage();
            f.Show();
           this.Hide();

        }

        private void splash_Load(object sender, EventArgs e)
        {

        }
    }
}
