
namespace WinFormsL
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.widthlabel = new System.Windows.Forms.Label();
            this.heightlabel = new System.Windows.Forms.Label();
            this.spinewidthlabel = new System.Windows.Forms.Label();
            this.widthnumval = new System.Windows.Forms.NumericUpDown();
            this.heightnumval = new System.Windows.Forms.NumericUpDown();
            this.spinenumval = new System.Windows.Forms.NumericUpDown();
            this.okbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthnumval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightnumval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinenumval)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.widthlabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.heightlabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.spinewidthlabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.widthnumval, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.heightnumval, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.spinenumval, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.okbutton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cancelbutton, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // widthlabel
            // 
            resources.ApplyResources(this.widthlabel, "widthlabel");
            this.widthlabel.Name = "widthlabel";
            // 
            // heightlabel
            // 
            resources.ApplyResources(this.heightlabel, "heightlabel");
            this.heightlabel.Name = "heightlabel";
            // 
            // spinewidthlabel
            // 
            resources.ApplyResources(this.spinewidthlabel, "spinewidthlabel");
            this.spinewidthlabel.Name = "spinewidthlabel";
            // 
            // widthnumval
            // 
            resources.ApplyResources(this.widthnumval, "widthnumval");
            this.widthnumval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthnumval.Name = "widthnumval";
            this.widthnumval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // heightnumval
            // 
            resources.ApplyResources(this.heightnumval, "heightnumval");
            this.heightnumval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heightnumval.Name = "heightnumval";
            this.heightnumval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // spinenumval
            // 
            resources.ApplyResources(this.spinenumval, "spinenumval");
            this.spinenumval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinenumval.Name = "spinenumval";
            this.spinenumval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // okbutton
            // 
            resources.ApplyResources(this.okbutton, "okbutton");
            this.okbutton.Name = "okbutton";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // cancelbutton
            // 
            resources.ApplyResources(this.cancelbutton, "cancelbutton");
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthnumval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightnumval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinenumval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Label widthlabel;
        private System.Windows.Forms.Label heightlabel;
        private System.Windows.Forms.Label spinewidthlabel;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.NumericUpDown widthnumval;
        private System.Windows.Forms.NumericUpDown heightnumval;
        private System.Windows.Forms.NumericUpDown spinenumval;
    }
}