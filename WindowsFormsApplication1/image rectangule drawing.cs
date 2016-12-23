using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace WindowsFormsApplication1
{
    class image_rectangule_drawing
    {
        public Image DrawRectangleInPicture(Image image1, Point p0, Point p1, Color RectColor, int LineWidth)//, DashStyle ds)
        {
            if (image1 == null) return null;
          
            Bitmap bm = new Bitmap(image1, image1.Width, image1.Height);

            using (Graphics g = Graphics.FromImage(bm))
            {

                Brush brush = new SolidBrush(RectColor);
                Pen pen = new Pen(brush, LineWidth);
                pen.DashStyle = DashStyle.Solid;
                g.DrawRectangle(pen, new Rectangle(p0.X, p0.Y, Math.Abs(p0.X - p1.X), Math.Abs(p0.Y - p1.Y)));
                g.Dispose();
            }
            
           return bm;
                  
        }
                                                                   
        //private int pointStartX, pointStartY, pointEndX, pointEndY  //定义全局变量 
        //private Bitmap bitmapSource = null;                         //初始化中  
                 
        //string strPath = "C:\\Users\\Public\\Pictures\\Sample Pictures\\22.jpg";
        //       bitmapSource = new Bitmap(strPath);
        ////在MouseDown事件中记下起始点           
        //       pointStartX = e.X;
        //       pointStartY = e.Y;
        ////C#中利用GDI+ ，在MouseMove事件中绘制矩形    
        //     int iWidth = e.X - pointStartX;
        //     int iHeight = e.Y - pointStartY;
        //     if (e.Button == MouseButtons.Left)
        //     {
        //         // 每次鼠标移动都拷贝原图bitmapSource，去除之前的留下的矩形
        //         Bitmap bitmap = new Bitmap(bitmapSource, 500, 500);
        //         Pen pen = new Pen(Color.Red);
        //         Graphics gh = Graphics.FromImage(bitmap);
        //         Rectangle rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
        //         // 画矩形
        //         gh.DrawRectangle(pen, rectNew);
        //         // 显示在画板上
        //        this.CreateGraphics().DrawImage(bitmap, 0, 0, 500, 500);
        //     }
        //   //用C#在Form1表單上有1個pictureBox單滑鼠點在 pictureBox上滑鼠之X座標<=105 && Y座標<=100 之範圍內畫1個矩形的框框

        //    Graphics g1; 
        //    Pen p1;
        //    p1 = new Pen(Color.Red,6);


        // //而矩形要畫的
        //  g1.DrawRectangle(p1, 0, 200, 105, 516);  
    }
}
