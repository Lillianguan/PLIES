using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class image : Form
    {
        public static image pCurrentwin = null;
        public image()
        {
            InitializeComponent();  
        }
        private Point _startLocation;
        //int k = 2;
        //Form1 form1;

        private void Form2_MouseWheel(object sender, MouseEventArgs e)
        {        
            Point mousePoint = this.panel2.PointToScreen(e.Location);           // get screen point 
            if (this.panel2.RectangleToScreen(this.panel2.ClientRectangle).Contains(mousePoint))      // whether in panel
            {
                this.panel2.AutoScrollPosition = new Point(this.panel2.HorizontalScroll.Value, panel2.VerticalScroll.Value - e.Delta);
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _startLocation = e.Location;
                Cursor = Cursors.SizeAll;
            }
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int xOffset = _startLocation.X - e.X;
                int yOffset = _startLocation.Y - e.Y;
                this.panel2.AutoScrollPosition = new Point(this.panel2.HorizontalScroll.Value + xOffset, panel2.VerticalScroll.Value + yOffset);
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }
        
        int k = 2;
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.C)
             {
                if (k % 2 != 1)
                {
                    Image img = Image.FromFile(@"C:\Users\Cailin\Desktop\Project H-C\Change picture\2_b_10_0002698__1_0002.jpg");
                    pictureBox1.Image = img;
                }
                else
                {
                    //Image img = Image.FromFile(form1.fileEntries[form1.controlnumber]); //object reference not set to an instance of an object
                    Image img = Image.FromFile(@"C:\Users\Cailin\Desktop\Project H-C\Color picture\2_b_10_0002011__1.bmp");
                    pictureBox1.Image = img;
                }
                k++;
             }

            if (e.KeyCode == Keys.V)        
            {
                if (k % 2 != 1)
                {
                    Image img = Image.FromFile(@"C:\Users\Cailin\Desktop\Project H-C\Bilder\2_b_10_0002710__1.jpg");
                    pictureBox1.Image = img;
                }
                else
                {
                    //Image img = Image.FromFile(form1.fileEntries[form1.controlnumber]); //object reference not set to an instance of an object
                    Image img = Image.FromFile(@"C:\Users\Cailin\Desktop\Project H-C\Bilder\2_b_10_0002710__1.bmp");
                    pictureBox1.Image = img;
                }
                k++;
            }
        }


        
       // private void pictureBox1_KeyDown(object sender, KeyEventArgs e)
       // {
            // when there are 2 pictures,to juge the name is the same or not, if they have the same name, than go to the picture of same name.
            //// Or to juge the controlnumber,if the number is 0 or 3,to go into different picture
            //int number = form1.controlnumber;
            //if (number == 0 && k % 2 != 0)
            //{
            //    Image img = Image.FromFile(@"C:\Users\zhengh\Desktop\jpg\2_b_10_0002698__1_0002.jpg");
            //    pictureBox1.Image = img;
            //}
            //else
            //{
            //    if (number == 0 && k % 2 == 0)
            //    {
            //        Image img = Image.FromFile(@"C:\Users\zhengh\Desktop\project\HalbeAufloesung\2_b_10_0002011__1_Grau.bmp");
            //        pictureBox1.Image = img;
            //    }
            //    else
            //    {
            //        k = 2;
            //        if (number == 3 && k % 2 != 0)
            //        {
            //            Image img = Image.FromFile(@"C:\Users\zhengh\Desktop\jpg\2_b_10_0002698__1_0005.jpg");
            //            pictureBox1.Image = img;
            //        }
            //        else
            //        {
            //            Image img = Image.FromFile(@"C:\Users\zhengh\Desktop\project\HalbeAufloesung\2_b_10_0002698__1_Grau.bmp");
            //            pictureBox1.Image = img;
            //        }
            //    }
            //}

            // when only have one picture to show

       //}



    }
}
