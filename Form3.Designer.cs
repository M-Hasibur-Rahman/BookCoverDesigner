
namespace WinFormsL
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CenterradioButton = new System.Windows.Forms.RadioButton();
            this.RightradioButton = new System.Windows.Forms.RadioButton();
            this.LeftradioButton = new System.Windows.Forms.RadioButton();
            this.fontsizenum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsizenum)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.CenterradioButton);
            this.groupBox1.Controls.Add(this.RightradioButton);
            this.groupBox1.Controls.Add(this.LeftradioButton);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // CenterradioButton
            // 
            resources.ApplyResources(this.CenterradioButton, "CenterradioButton");
            this.CenterradioButton.Name = "CenterradioButton";
            this.CenterradioButton.TabStop = true;
            this.CenterradioButton.UseVisualStyleBackColor = true;
            this.CenterradioButton.CheckedChanged += new System.EventHandler(this.CenterradioButton_CheckedChanged);
            // 
            // RightradioButton
            // 
            resources.ApplyResources(this.RightradioButton, "RightradioButton");
            this.RightradioButton.Name = "RightradioButton";
            this.RightradioButton.TabStop = true;
            this.RightradioButton.UseVisualStyleBackColor = true;
            this.RightradioButton.CheckedChanged += new System.EventHandler(this.RightradioButton_CheckedChanged);
            // 
            // LeftradioButton
            // 
            resources.ApplyResources(this.LeftradioButton, "LeftradioButton");
            this.LeftradioButton.Name = "LeftradioButton";
            this.LeftradioButton.TabStop = true;
            this.LeftradioButton.UseVisualStyleBackColor = true;
            this.LeftradioButton.CheckedChanged += new System.EventHandler(this.LeftradioButton_CheckedChanged);
            this.LeftradioButton.Click += new System.EventHandler(this.LeftradioButton_Click);
            // 
            // fontsizenum
            // 
            resources.ApplyResources(this.fontsizenum, "fontsizenum");
            this.fontsizenum.Name = "fontsizenum";
            this.fontsizenum.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Cancelbutton
            // 
            resources.ApplyResources(this.Cancelbutton, "Cancelbutton");
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // OKbutton
            // 
            resources.ApplyResources(this.OKbutton, "OKbutton");
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fontsizenum);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsizenum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CenterradioButton;
        private System.Windows.Forms.RadioButton RightradioButton;
        private System.Windows.Forms.RadioButton LeftradioButton;
        private System.Windows.Forms.NumericUpDown fontsizenum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox textBox1;
    }
}