using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsL
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.textBox1.AutoSize = false;
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = ScrollBars.Vertical;
        }

        public string TextBoxVal
        {
            get { return textBox1.Text; }
        }

        public decimal FontVal
        {
            get { return fontsizenum.Value; }
        }

        
        public string RadioButChecked()
        {
            if(LeftradioButton.Checked)
            {
                //textBox1.TextAlign = HorizontalAlignment.Center;
                return LeftradioButton.Text;
            }
            else if (RightradioButton.Checked)
            {
                return RightradioButton.Text;
            }
            else if (CenterradioButton.Checked)
            {
                return CenterradioButton.Text;
            }
            else
                return LeftradioButton.Text;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LeftradioButton_Click(object sender, EventArgs e)
        {

        }

        private void LeftradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LeftradioButton.Checked == true) 
            {
                textBox1.TextAlign = HorizontalAlignment.Left;
            }
        }

        private void CenterradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CenterradioButton.Checked == true)
            {
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void RightradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RightradioButton.Checked == true)
            {
                textBox1.TextAlign = HorizontalAlignment.Right;
            }
        }
    }
}
