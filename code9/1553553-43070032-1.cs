    Bitmap cuttedImage;
    
    using(Bitmap originalImage = new Bitmap("filePathName"))
    {
       Rectangle cropRect = new Rectangle(...);
    
       cuttedImage = originalImage .Clone(cropRect, originalBmp.PixelFormat);
    }
    
    cuttedImage.Save("filePathName", ImageFormat.Jpeg);
    cuttedImage.Dispose();
