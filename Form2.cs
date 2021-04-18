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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            
        }


        public decimal Widthval
        {
            get { return widthnumval.Value; }
            //set { widthnumval.Value = value; }
        }

        public decimal Heightval
        {
            get { return heightnumval.Value; }
            //set { heightnumval.Value = value; }
        }

        public decimal Spineval
        {
            get {return spinenumval.Value; }
            //set { spinenumval.Value = value; }
        }
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
