using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinForms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Mihqas/PacmanWinForms");
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Mihqas");
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

        }
    }
}
