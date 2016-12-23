using System;
using System.Collections.Generic;
//using System.Linq;
using System.Drawing;
using System.Text;
//using OpenCvSharp;


namespace WindowsFormsApplication1
{
    public class OcrWord
    {
        public Rectangle position = new Rectangle(0, 0, 1, 1);
        public Rectangle paragraph = new Rectangle(0, 0, 1, 1);
        public String language = "";
        public String fontFace = "";
        public int fontSize = Int32.MinValue;
        public String text = "";
        public String fileName = "";

        public OcrWord()
        {
        }

        public OcrWord(Rectangle position, String myText)
        {
            this.position = position;
            text = myText;
        }

        public Point topLeft
        {
            get { return new Point(position.Left, position.Top); }
        }

        public Point bottomRight
        {
            get { return new Point(position.Right, position.Bottom); }
        }
    }
}
