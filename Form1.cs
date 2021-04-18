using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Threading;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsL
{
    public partial class Form1 : Form
    {
        public static int getwidthval=350;
        public static int getheightval = 600;
        public static int getspineval = 80;
        public Color col = new Color();
        public static int rectX;
        public static int rectY;
        public Color coltext = new Color();
        
        public static string getaddtext;
        public static int getaddtextfontsize=16;
        public Form1()
        {
            
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            InitializeComponent();
            //https://stackoverflow.com/questions/5314041/set-minimum-window-size-in-c-sharp-net
            //https://stackoverflow.com/questions/10173147/easiest-way-to-change-font-and-font-size
            this.MinimumSize = new Size(800, 600);
            this.label1.Font = new Font("Arial", 10, FontStyle.Bold);
            this.label2.Font = new Font("Arial", 10, FontStyle.Bold);
            this.label3.Font = new Font("Arial", 10, FontStyle.Bold);
            this.label4.Font = new Font("Arial", 10, FontStyle.Bold);
            this.label5.Font = new Font("Arial", 11, FontStyle.Regular);
            this.label6.Font = new Font("Arial", 11, FontStyle.Regular);
            this.Englishmenuitem.CheckState = CheckState.Checked;

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        //https://stackoverflow.com/questions/19674743/dynamically-resizing-font-to-fit-space-while-using-graphics-drawstring
        private Font FindFont(System.Drawing.Graphics g, string longString, int Width, int Height, Font PreferedFont)
        {
            SizeF RealSize = g.MeasureString(longString, PreferedFont);
            float HeightScaleRatio = Height / RealSize.Height;
            float WidthScaleRatio = Width / RealSize.Width;

            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio)
               ? ScaleRatio = HeightScaleRatio
               : ScaleRatio = WidthScaleRatio;

            float ScaleFontSize = PreferedFont.Size * ScaleRatio;

            return new Font(PreferedFont.FontFamily, ScaleFontSize);
        }
       
        //http://csharphelper.com/blog/2015/05/rotate-around-a-point-other-than-the-origin-in-c/
        private Matrix RotateAroundPoint(float angle, Point center) //rotate text in spine
        {
            // Translate the point to the origin.
            Matrix result = new Matrix();
            result.RotateAt(angle, center);
            return result;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen line = new Pen(Color.Gray, 4);
            col = Color.Pink;
            SolidBrush brush = new SolidBrush(col);
            //https://stackoverflow.com/questions/5941979/c-sharp-drawing-a-rectangle-on-a-picturebox
            //rectX = pictureBox1.Width * 10 / 100;
            //rectY = pictureBox1.Height * 10 / 100;
            //int outerRectwidth = pictureBox1.Width * 35 / 100; //350
            //int smallRectWidth = pictureBox1.Height * 10 / 100; //81
            //int wholerectHeight = pictureBox1.Height * 80 / 100; //800

            //e.Graphics.DrawRectangle(line, rectX, rectY, outerRectwidth, wholerectHeight); //left rectangle
            //e.Graphics.DrawRectangle(line, rectX + outerRectwidth, rectY, smallRectWidth, wholerectHeight); //middle rectangle
            //e.Graphics.DrawRectangle(line, rectX + outerRectwidth + smallRectWidth, rectY, outerRectwidth, wholerectHeight); //right rectangle
            
            rectX = pictureBox1.Width / 2 - (2*getwidthval+getspineval)/2;
            rectY = pictureBox1.Height / 2 - getheightval /2;
            e.Graphics.DrawRectangle(line, rectX, rectY, getwidthval, getheightval); //left rectangle
            e.Graphics.DrawRectangle(line, rectX + getwidthval, rectY, getspineval, getheightval); //middle rectangle
            e.Graphics.DrawRectangle(line, rectX + getwidthval + getspineval, rectY, getwidthval, getheightval); //right rectangle

            e.Graphics.FillRectangle(brush, rectX, rectY, getwidthval-1, getheightval-1); //left rectangle
            e.Graphics.FillRectangle(brush, rectX + getwidthval, rectY, getspineval-1, getheightval-1); //middle rectangle
            e.Graphics.FillRectangle(brush, rectX + getwidthval + getspineval, rectY, getwidthval-1, getheightval-1); //right rectangle
            if (textBox1.Text.Length > 0)
            {
                String drawString = textBox1.Text;
                //https://stackoverflow.com/questions/206717/how-do-i-replace-multiple-spaces-with-a-single-space-in-c
                drawString = Regex.Replace(drawString, @"\s+", " ");
                Font drawFont = new Font("Arial", 32);
                SolidBrush drawBrush = new SolidBrush(coltext);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                drawFormat.Alignment = StringAlignment.Center;
                //drawFormat.FormatFlags = StringFormatFlags.NoWrap;
                //RectangleF drawRect = new RectangleF(rectX + getwidthval, rectY + (getheightval * 70 / 100), getspineval/2, getheightval /4);
                //Pen blackPen = new Pen(Color.Transparent);
                //e.Graphics.DrawRectangle(blackPen, rectX + getwidthval, rectY + (getheightval * 70 / 100), getspineval/2, getheightval / 4);

                Font checktitlespine = FindFont(e.Graphics, drawString, getheightval / 2, getspineval, drawFont);
                // Draw string to screen.
                Point center = new Point(rectX + getwidthval + getspineval / 2, rectY + (getheightval * 3 / 4));
                //e.Graphics.TranslateTransform(rectX + getwidthval, rectY + (getheightval * 3 / 4));
                e.Graphics.Transform=RotateAroundPoint(180, center);
                e.Graphics.DrawString(drawString, checktitlespine, drawBrush, rectX + getwidthval, rectY + (getheightval * 3 /4), drawFormat);
                
                e.Graphics.ResetTransform();
                /////////////////////////////////////////////////////

                
                Font drawFontbig = new Font("Arial",32);
                SolidBrush drawBrushbig = new SolidBrush(coltext);

                // Set format of string.
                StringFormat drawFormatbig = new StringFormat();
                //drawFormat.FormatFlags = StringFormatFlags.DirectionHorizontal;
                drawFormatbig.Alignment = StringAlignment.Center;

                Font checktitle = FindFont(e.Graphics, drawString, getwidthval, (getheightval * 1 / 3), drawFontbig);
                // Draw string to screen.
                e.Graphics.DrawString(drawString, checktitle, drawBrushbig, rectX + getwidthval + getspineval + (getwidthval / 2), rectY + (getheightval / 7), drawFormatbig);
            }
            if (textBox2.Text.Length > 0)
            {
                //////////////////////////////////////////////
                String drawStringauthor = textBox2.Text;
                drawStringauthor = Regex.Replace(drawStringauthor, @"\s+", " ");
                Font drawFontauthor = new Font("Arial", 24);
                SolidBrush drawBrushauthor = new SolidBrush(coltext);

                // Set format of string.
                StringFormat drawFormatauthor = new StringFormat();
                //drawFormat.FormatFlags = StringFormatFlags.DirectionHorizontal;
                drawFormatauthor.Alignment = StringAlignment.Center;
                Font checkauthor = FindFont(e.Graphics, drawStringauthor, getwidthval, (getheightval * 1 / 6), drawFontauthor);
                // Draw string to screen.
                e.Graphics.DrawString(drawStringauthor, checkauthor, drawBrushauthor, rectX + getwidthval + getspineval + (getwidthval / 2), rectY + (getheightval * 40 / 100), drawFormatauthor);


                ///////
                
                //Font drawFontspineauthor = new Font("Arial", 16);
                SolidBrush drawBrushspineauthor = new SolidBrush(coltext);

                StringFormat drawFormatspineauthor = new StringFormat();
                drawFormatspineauthor.FormatFlags = StringFormatFlags.DirectionVertical;
                drawFormatspineauthor.Alignment = StringAlignment.Center;
                Font checkauthorspine = FindFont(e.Graphics, drawStringauthor, getheightval / 2, getspineval, drawFontauthor);
                // Draw string to screen.
                Point center = new Point(rectX + getwidthval + getspineval / 2, rectY + (getheightval / 4));
                //e.Graphics.TranslateTransform(rectX + getwidthval, rectY + (getheightval * 3 / 4));
                e.Graphics.Transform = RotateAroundPoint(180, center);
                e.Graphics.DrawString(drawStringauthor, checkauthorspine, drawBrushspineauthor, rectX + getwidthval, rectY + (getheightval / 4), drawFormatspineauthor);
                e.Graphics.ResetTransform();
            }
            
            foreach(var txts in textlist)
            {
                e.Graphics.DrawString(txts.getaddtext, new Font("Arial", txts.getaddtextfontsize), new SolidBrush(coltext), txts.textloc, txts.drawFormat);
                
                if (txts.rightclicked == true)
                {
                    
                    e.Graphics.DrawRectangle(new Pen(InvertMeAColour(col), 1), txts.rectangle);
                    //pictureBox1.Refresh();
                }
            }
            

        }
        //public int rightclicked = 0;
        //https://stackoverflow.com/questions/1165107/how-do-i-invert-a-colour
        Color InvertMeAColour(Color ColourToInvert)
        {
            return Color.FromArgb((byte)~ColourToInvert.R, (byte)~ColourToInvert.G, (byte)~ColourToInvert.B);
        }

        private void laststate()
        {
            var formsizelast = this.Size;
            var loclast = this.Location;
            var splitdistlast = this.splitContainer1.SplitterDistance;
            var textbox1last = this.textBox1.Text;
            var textbox2last = this.textBox2.Text;
            var engcheck = this.Englishmenuitem.CheckState;
            var polcheck = this.Polishmenuitem.CheckState;
            InitializeComponent();
            this.Size = formsizelast;
            this.Location = loclast;
            this.splitContainer1.SplitterDistance = splitdistlast;
            this.textBox1.Text = textbox1last;
            this.textBox2.Text = textbox2last;
            this.Englishmenuitem.CheckState = engcheck;
            this.Polishmenuitem.CheckState = polcheck;
            this.label1.Font = new Font("Arial", 10, FontStyle.Bold); //forgot to add this as properties during localization for default
            this.label2.Font = new Font("Arial", 10, FontStyle.Bold); //so have to put it here
            this.label3.Font = new Font("Arial", 10, FontStyle.Bold);
            this.label4.Font = new Font("Arial", 10, FontStyle.Bold);
        }
        //public static ResourceManager rm = new ResourceManager("WindowsFormsApp1.pl_local", Assembly.GetExecutingAssembly());
        // since getting string from resx is not allowed used below link for localization
        //https://supportcenter.devexpress.com/ticket/details/t425466/how-to-localize-a-winforms-application
        private void ChangeLanguage(string lang)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture?view=net-5.0
            CultureInfo.CurrentUICulture = new CultureInfo(lang, false);
            Controls.Clear();
            
        }

       
        private void Englishmenuitem_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/7844711/how-to-change-the-checked-state-of-a-toolstripitem-in-winforms
            //this.label1.Text = rm.GetString("Title"); //not allowed
            
            Polishmenuitem.CheckState = CheckState.Unchecked;
            Englishmenuitem.CheckState = CheckState.Checked;
            
            //this.Refresh();
            //this.label1.Text = rm.GetString("Title"); //not allowed
            ChangeLanguage("en");
            laststate();
            
        }
       
        private void Polishmenuitem_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/7844711/how-to-change-the-checked-state-of-a-toolstripitem-in-winforms
            //label1.Text = rm.GetString("Title");  //since this is not allowed 

            Polishmenuitem.CheckState = CheckState.Checked;
            Englishmenuitem.CheckState = CheckState.Unchecked;
            ChangeLanguage("pl-PL");
            laststate();
            //this.Refresh();


        }

        private void newmenuitem_Click(object sender, EventArgs e)
        {
            Form2 newdialogbox = new Form2();
            if (newdialogbox.ShowDialog() == DialogResult.OK)
            {
                col = Color.Transparent;
                coltext = Color.Transparent;
                textBox1.Text = "";
                textBox2.Text = "";
                getwidthval = Convert.ToInt32(newdialogbox.Widthval);
                getheightval = Convert.ToInt32(newdialogbox.Heightval);
                getspineval = Convert.ToInt32(newdialogbox.Spineval);
                //this.textBox1.Text = getwidthval.ToString();
                rectX = pictureBox1.Width / 2 - getwidthval / 2;
                rectY = pictureBox1.Height / 2 - getheightval / 2;
                //paint event global variable clear
                pictureBox1.Refresh();
                
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Black;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                col = colorDialog.Color;
                pictureBox1.Refresh();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.Black;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                coltext = colorDialog.Color;
                pictureBox1.Refresh();
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            pictureBox1.Width = splitContainer1.Panel1.Width;
            pictureBox1.Refresh();
        }

        private void openmenuitem_Click(object sender, EventArgs e)
        {
            //https://www.c-sharpcorner.com/article/dialog-boxes-in-c-sharp/
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open a Text File";
            ofd.Filter = "Text Files (*.xml) | *.xml | All Files(*.*) | *.*"; //Here you can filter which all files you wanted allow to open  
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                
            }
        }

        private void savemenuitem_Click(object sender, EventArgs e)
        {
            //https://www.c-sharpcorner.com/article/dialog-boxes-in-c-sharp/
            SaveFileDialog sfdlg = new SaveFileDialog();
            sfdlg.Filter = "Text Files (*.xml) | *.xml"; //Here you can filter which all files you wanted allow to open  
            if (sfdlg.ShowDialog() == DialogResult.OK)
            {
                  
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            rectX = pictureBox1.Width / 2 - (2 * getwidthval + getspineval) / 2;
            rectY = pictureBox1.Height / 2 - getheightval / 2;
            //foreach (var txts in textlist)
            //{
            //    txts.textloc = new Point(prevtextloc.X-rectX, prevtextloc.Y-rectY);
            //}
            pictureBox1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            coltext = Color.Black;
            pictureBox1.Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            coltext = Color.Black;
            pictureBox1.Refresh();
        }

        
        public int picboxclicked = 0;
        public string gettextalignment;
        public class addedtext
        {
            public string getaddtext;
            public string gettextalignment;
            public int getaddtextfontsize;
            public Point textloc;
            public Rectangle rectangle; //created to wrap text and will be used to update text for doubleclick event
            public SizeF rectanglesize;
            public StringFormat drawFormat;
            public bool rightclicked;
           
        }

        public List<addedtext> textlist = new List<addedtext>();
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 addtextform = new Form3();
            //addtextform.ShowDialog();
            if (addtextform.ShowDialog() == DialogResult.OK)
            {
                getaddtext = addtextform.TextBoxVal;
                gettextalignment = addtextform.RadioButChecked();
                getaddtextfontsize = Convert.ToInt32(addtextform.FontVal);
                //txt.getaddtext = addtextform.TextBoxVal;
                //txt.gettextalignment = addtextform.RadioButChecked();
                //txt.getaddtextfontsize = Convert.ToInt32(addtextform.FontVal);
                picboxclicked = 1;
                coltext = Color.Black;
            }
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (picboxclicked == 1)
            {
                pictureBox1.Cursor = Cursors.Cross;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Default;
            }
           
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Refresh();
        }
        public Point prevtextloc = new Point();
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (picboxclicked==1)
            {
                picboxclicked = 0;
                            
                addedtext txt = new addedtext();
                //txt.rightclicked = false;
                if (gettextalignment == "Center")
                {
                    using (Graphics g = pictureBox1.CreateGraphics())
                    {
                        SizeF textsize = new SizeF();
                        //float fontsize = (float)getaddtextfontsize;
                        //textsize = g.MeasureString(txt.getaddtext, new Font("Arial", txt.getaddtextfontsize));
                        //Point n = new Point(e.X - (int)textsize.Width / 2 + (int)textsize.Width / 2, e.Y - ((int)textsize.Height / 2) + (int)textsize.Height / 2);
                        Font addTfont = new Font("Arial", getaddtextfontsize);
                        SolidBrush drawBrush = new SolidBrush(coltext);
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.LineAlignment = StringAlignment.Center;
                        drawFormat.Alignment = StringAlignment.Center;
                        //g.DrawString(getaddtext, addTfont, drawBrush, n, drawFormat); // Drew rectangle to check if alignment is correct
                        //g.DrawRectangle(new Pen(Color.Black, 1), e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2, textsize.Width, textsize.Height);
                        
                        txt.getaddtext = getaddtext;
                        txt.getaddtextfontsize = getaddtextfontsize;
                        textsize = g.MeasureString(txt.getaddtext, new Font("Arial", txt.getaddtextfontsize));
                        txt.textloc = new Point(e.X - (int)textsize.Width / 2 + (int)textsize.Width / 2, e.Y - ((int)textsize.Height / 2) + (int)textsize.Height / 2);
                        txt.rectangle = new Rectangle(e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                        txt.drawFormat = drawFormat;
                        txt.rightclicked = false;
                        textlist.Add(txt);
                        prevtextloc = new Point(e.X, e.Y);
                        //txt.rightclicked = false;
                    }
                }
                if (gettextalignment == "Left")
                {
                    using (Graphics g = pictureBox1.CreateGraphics())
                    {
                        SizeF textsize = new SizeF();
                        //float fontsize = (float)getaddtextfontsize;
                        //textsize = g.MeasureString(txt.getaddtext, new Font("Arial", txt.getaddtextfontsize));
                        //Point n = new Point(e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2);
                        Font addTfont = new Font("Arial", getaddtextfontsize);
                        SolidBrush drawBrush = new SolidBrush(coltext);
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.LineAlignment = StringAlignment.Near;
                        drawFormat.Alignment = StringAlignment.Near;
                        //g.DrawString(getaddtext, addTfont, drawBrush, n, drawFormat);
                        //g.DrawRectangle(new Pen(Color.Black, 1), e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2, textsize.Width, textsize.Height);

                        txt.getaddtext = getaddtext;
                        txt.getaddtextfontsize = getaddtextfontsize;
                        textsize = g.MeasureString(txt.getaddtext, new Font("Arial", txt.getaddtextfontsize));
                        txt.textloc = new Point(e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2);
                        txt.rectangle = new Rectangle(e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                        txt.drawFormat = drawFormat;
                        txt.rightclicked = false;
                        textlist.Add(txt);
                        prevtextloc = new Point(e.X, e.Y);
                        //txt.rightclicked = false;
                    }
                }
                if (gettextalignment == "Right")
                {
                    using (Graphics g = pictureBox1.CreateGraphics())
                    {
                        SizeF textsize = new SizeF();
                        //float fontsize = (float)getaddtextfontsize;
                        //textsize = g.MeasureString(txt.getaddtext, new Font("Arial", txt.getaddtextfontsize));
                        //Point n = new Point(e.X + (int)textsize.Width / 2, e.Y + (int)textsize.Height / 2);
                        Font addTfont = new Font("Arial", getaddtextfontsize);
                        SolidBrush drawBrush = new SolidBrush(coltext);
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.LineAlignment = StringAlignment.Far;
                        drawFormat.Alignment = StringAlignment.Far;
                        //g.DrawString(getaddtext, addTfont, drawBrush, n, drawFormat);
                        //g.DrawRectangle(new Pen(Color.Black, 1), e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2, textsize.Width, textsize.Height);

                        txt.getaddtext = getaddtext;
                        txt.getaddtextfontsize = getaddtextfontsize;
                        textsize = g.MeasureString(txt.getaddtext, new Font("Arial", txt.getaddtextfontsize));
                        txt.textloc = new Point(e.X + (int)textsize.Width / 2, e.Y + (int)textsize.Height / 2);
                        txt.rectangle = new Rectangle(e.X - (int)textsize.Width / 2, e.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                        txt.drawFormat = drawFormat;
                        txt.rightclicked = false;
                        textlist.Add(txt);
                        prevtextloc = new Point(e.X, e.Y);
                        //txt.rightclicked = false;
                    }
                }
                
                pictureBox1.Refresh();
                pictureBox1.Cursor = Cursors.Default;

            }
            if (e.Button == MouseButtons.Right)
            {
                foreach (var txts in textlist)
                {
                    txts.rightclicked = false;
                    
                        if (txts.rectangle.Contains(e.Location))
                        {
                            //rightclicked = 1;

                            txts.rightclicked = true;
                            
                            if (txts.gettextalignment == "Right")
                            {
                                using (Graphics g = pictureBox1.CreateGraphics())
                                {
                                    SizeF textsize = new SizeF();
                                    textsize = g.MeasureString(txts.getaddtext, new Font("Arial", txts.getaddtextfontsize));
                                    txts.textloc = new Point(prevtextloc.X + (int)textsize.Width / 2, prevtextloc.Y + (int)textsize.Height / 2);
                                    txts.rectangle = new Rectangle(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                                    StringFormat drawFormat = new StringFormat();
                                    drawFormat.LineAlignment = StringAlignment.Far;
                                    drawFormat.Alignment = StringAlignment.Far;
                                    txts.drawFormat = drawFormat;
                                    
                                }
                                
                            }
                            if (txts.gettextalignment == "Center")
                            {
                                using (Graphics g = pictureBox1.CreateGraphics())
                                {
                                    SizeF textsize = new SizeF();
                                    textsize = g.MeasureString(txts.getaddtext, new Font("Arial", txts.getaddtextfontsize));
                                    txts.textloc = new Point(prevtextloc.X - (int)textsize.Width / 2 + (int)textsize.Width / 2, prevtextloc.Y - ((int)textsize.Height / 2) + (int)textsize.Height / 2);
                                    txts.rectangle = new Rectangle(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                                    StringFormat drawFormat = new StringFormat();
                                    drawFormat.LineAlignment = StringAlignment.Center;
                                    drawFormat.Alignment = StringAlignment.Center;
                                    txts.drawFormat = drawFormat;
                               
                                }
                            }
                            if (txts.gettextalignment == "Left")
                            {
                                using (Graphics g = pictureBox1.CreateGraphics())
                                {
                                    SizeF textsize = new SizeF();
                                    textsize = g.MeasureString(txts.getaddtext, new Font("Arial", txts.getaddtextfontsize));
                                    txts.textloc = new Point(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2);
                                    txts.rectangle = new Rectangle(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                                    StringFormat drawFormat = new StringFormat();
                                    drawFormat.LineAlignment = StringAlignment.Near;
                                    drawFormat.Alignment = StringAlignment.Near;
                                    txts.drawFormat = drawFormat;
                               
                                }
                            }
                        }
                    
                }
                pictureBox1.Refresh();
            }
            
           //pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3 addtextform = new Form3();
            
            string newtext;
            string textalignment;
            int addtextfontsize;
            //Rectangle rec;
            foreach (var txts in textlist)
            {
                //https://stackoverflow.com/questions/11260397/how-can-i-make-the-rectangles-clickable-c-sharp
                if (txts.rectangle.Contains(e.Location))
                {
                    if(addtextform.ShowDialog()==DialogResult.OK)
                    {
                        newtext = addtextform.TextBoxVal;
                        textalignment = addtextform.RadioButChecked();
                        addtextfontsize = Convert.ToInt32(addtextform.FontVal);
                        
                        //Updated values:

                        txts.getaddtext = newtext;
                        txts.getaddtextfontsize = addtextfontsize;
                        if(textalignment=="Right")
                        {
                            using (Graphics g = pictureBox1.CreateGraphics())
                            {
                                SizeF textsize = new SizeF();
                                textsize = g.MeasureString(txts.getaddtext, new Font("Arial", txts.getaddtextfontsize));
                                txts.textloc = new Point(prevtextloc.X + (int)textsize.Width / 2, prevtextloc.Y + (int)textsize.Height / 2);
                                txts.rectangle = new Rectangle(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.LineAlignment = StringAlignment.Far;
                                drawFormat.Alignment = StringAlignment.Far;
                                txts.drawFormat = drawFormat;
                                
                            }
                            pictureBox1.Refresh();
                        }
                        if (textalignment == "Center")
                        {
                            using (Graphics g = pictureBox1.CreateGraphics())
                            {
                                SizeF textsize = new SizeF();
                                textsize = g.MeasureString(txts.getaddtext, new Font("Arial", txts.getaddtextfontsize));
                                txts.textloc = new Point(prevtextloc.X - (int)textsize.Width / 2 + (int)textsize.Width / 2, prevtextloc.Y - ((int)textsize.Height / 2) + (int)textsize.Height / 2);
                                txts.rectangle = new Rectangle(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                                
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.LineAlignment = StringAlignment.Center;
                                drawFormat.Alignment = StringAlignment.Center;
                                txts.drawFormat = drawFormat;
                                
                            }
                        }
                        if (textalignment == "Left")
                        {
                            using (Graphics g = pictureBox1.CreateGraphics())
                            {
                                SizeF textsize = new SizeF();
                                textsize = g.MeasureString(txts.getaddtext, new Font("Arial", txts.getaddtextfontsize));
                                txts.textloc = new Point(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2);
                                txts.rectangle = new Rectangle(prevtextloc.X - (int)textsize.Width / 2, prevtextloc.Y - (int)textsize.Height / 2, (int)textsize.Width, (int)textsize.Height);
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.LineAlignment = StringAlignment.Near;
                                drawFormat.Alignment = StringAlignment.Near;
                                txts.drawFormat = drawFormat;
                               
                            }
                        }
                    }
                }
            }
            pictureBox1.Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (var txts in textlist.ToList())
                {
                    if(txts.rightclicked)
                    {
                        textlist.Remove(txts);
                        pictureBox1.Refresh();
                        break;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
    }
}
