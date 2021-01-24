    int w= 100;
    int h = 200;
    int ch = 3; //number of channels (ie. assuming 24 bit RGB in this case)
    
    byte[] imageData    = new byte[w*h*ch]; //you image data here
    Bitmap bitmap       = new Bitmap(w,h,PixelFormat.Format24bppRgb);
    BitmapData bmData   = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
    IntPtr pNative      = bmData.Scan0;
    Marshal.Copy(imageData,0,pNative,w*h*ch);
    bitmap.UnlockBits(bmData);
