using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PinCtrl
{
    public partial class Form2 : Form
    {
        public MainForm f1;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //f1.relationbtn();
            f1.OutputExcel(null,null);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            f1.Form1_FormClosing();
        }
   
    }
}
