    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    ....    
    
    //  This code saves the current Form Control.
    //  In order to save some other Control,
    //  replace "this" by the Control object
    Control ctl = this;
    Bitmap bm = new Bitmap(ctl.Bounds.Width, ctl.Bounds.Height);
    
    Graphics g = Graphics.FromImage(bm);
    
    g.CopyFromScreen(ctl.Left, ctl.Top, 0, 0, bm.Size);
    
    g.Dispose();
    
    bm.Save("bitmap.jpg", ImageFormat.Jpeg);
    ....
