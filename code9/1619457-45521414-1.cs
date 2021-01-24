    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    ....    
    
    Bitmap bm = new Bitmap(Bounds.Width, Bounds.Height);
    
    Graphics g = Graphics.FromImage(bm);
    
    g.CopyFromScreen(Left, Top, 0, 0, bm.Size);
    
    g.Dispose();
    
    bm.Save("bitmap.jpg", ImageFormat.Jpeg);
    ....
