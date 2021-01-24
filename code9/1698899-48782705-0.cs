    public static Bitmap GetBitmapFromIBSU(IBSU_ImageData imageData)
    {
        // Can't handle this.
        if (imageData.Format == IBSU_ImageFormat.IBSU_IMG_FORMAT_UNKNOWN)
            throw new NotSupportedException();
        Int32 stride = Math.Abs(imageData.Pitch);
        Byte[] data = new byte[imageData.Width * stride];
        Marshal.Copy(imageData.Buffer, data, 0, data.Length);
        // Write this function yourself. They're both enums so a simple switch-case should do.
        // GRAY probably means indexed 8bpp; then you need to give a generated palette to BuildImage in the next step.
        PixelFormat format = ConvertPixelformat(imageData.Format);
        // The function I linked in the description.
        Bitmap image = BuildImage(data, imageData.Width, imageData.Height, stride, format, null, null);
        // Bitmaps have their data from bottom to top. The negative Pitch value indicates this.
        // There is a really handy inbuilt function to fix this, though.
        if(imageData.Pitch < 0)
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
        // These will need conversion from ppi to dpi. Google it yourself.
        bitmap.SetResolution(imageData.ResolutionX,imageData.ResolutionY);
        return bitmap;
    }
