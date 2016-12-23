using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenCvSharp;
using System.IO;

namespace C_Sharp
{    
    class Process
    {
        public IplImage myImage;
        public IplImage originalImage;

        public Bitmap bitmap // supplies the current iamge as bitmap
        {
            get { return myImage.ToBitmap(); }
        }
        public Bitmap loadImage(String imagePath)
        {
            if (myImage != null)

                myImage.Dispose();

            myImage = new IplImage(imagePath, LoadMode.Color);

            originalImage = new IplImage(imagePath, LoadMode.Color);
            return myImage.ToBitmap();
        }

        public string Loadtxt()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string content;
                string file = fileDialog.FileName;
                StreamReader sr = new StreamReader(file, Encoding.GetEncoding("gb2312"));
                content = sr.ReadToEnd();
                return content;
            }
            return null;
        }

        public Image LoadImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap myBitmap = loadImage(fileDialog.FileName);
                return myBitmap;
            }
            return null;
        }
        public List<Control> AllControls = new List<Control>();
        public void FindControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                AllControls.Add(c);
                if (c.HasChildren)
                {
                    FindControls(c);
                }
            }
        }
        //public string Circle()
        //{
        //    string[] Imageshow = Directory.GetFiles(@"D:\\image\\HalbeAufloesung\\", "*.bmp");
        //    string[] Txt = Directory.GetFiles(@"D:\\image\\txtxml\\", "*.txt");
        //    DirectoryInfo Dir = new DirectoryInfo(@"D:\\image\\HalbeAufloesung\\");
        //    foreach (FileInfo f in Dir.GetFiles("*.bmp"))
        //    {
        //        string fs = f.ToString();
        //        return fs;
        //    }

        //    for (int i = 0; i < Imageshow.Length; i++)
        //    {
               
        //        Bitmap myBitmap = loadImage(Imageshow[i]);
        //        return myBitmap;
               
        //        StreamReader sr = new StreamReader(Txt[i], Encoding.GetEncoding("gb2312"));
        //        string ss = sr.ReadToEnd();
        //        string Fs = listBox1.Items[i].ToString();
        //        string name = Fs.Substring(0, Fs.LastIndexOf("."));
        //        textBox1.Text = name;
        //    }
        //}
       
}
    
}
