     Control ctl = this;
     Rectangle rectangle = ctl.Bounds;
     Bitmap bm = new Bitmap(rectangle.Width, rectangle.Height);
    
     Graphics g = Graphics.FromImage(bm);
     Rectangle bmRectangle = new Rectangle(0, 0, bm.Width, bm.Height);
     ctl.DrawToBitmap(bm, bmRectangle);
    
     g.Dispose();
    
     bm.Save("bitmap.jpg", ImageFormat.Jpeg);
