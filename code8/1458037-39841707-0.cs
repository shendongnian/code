    private static Bitmap CreateBitmapFromBytes(byte[] pixelValues, int width, int height)
        {
        //Create an image that will hold the image data
        Bitmap pic = new Bitmap(width, height, PixelFormat.Format16bppGrayScale);
        //Get a reference to the images pixel data
        Rectangle dimension = new Rectangle(0, 0, pic.Width, pic.Height);
        BitmapData picData = pic.LockBits(dimension, ImageLockMode.ReadWrite, pic.PixelFormat);
        IntPtr pixelStartAddress = picData.Scan0;
        //Copy the pixel data into the bitmap structure
        System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, pixelStartAddress, pixelValues.Length);
        pic.UnlockBits(picData);
        return pic;
        }
