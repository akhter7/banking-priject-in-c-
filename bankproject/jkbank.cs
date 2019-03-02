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
    public partial class jkbank : Form
    {
        private int childFormNumber = 0;

        public jkbank()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
      //      toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
      //      statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {
            loanform lf = new loanform();
            lf.Show();
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {
            fixedform ff = new fixedform();
            ff.Show();
        }

        private void jkbank_Load(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {
            savingform sf = new savingform();
            sf.Show();

        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            currentform cf = new currentform();
            cf.Show();
        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {
            balancesheet bst = new balancesheet();
            bst.Show();
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {
            customeraccdetail cad = new customeraccdetail();
            cad.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit d = new Deposit();
            d.Show();
        }

        private void withdrawlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdrwl w =new Withdrwl();
            w.Show();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer t = new Transfer();
            t.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       

     
    }
}
