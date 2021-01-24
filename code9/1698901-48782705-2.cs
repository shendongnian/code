    public static Bitmap GetBitmapFromIBSU(IBSU_ImageData imageData)
    {
        // Can't handle this.
        if (imageData.Format == IBSU_ImageFormat.IBSU_IMG_FORMAT_UNKNOWN)
            throw new NotSupportedException();
        Byte[] data = new byte[imageData.Width * Math.Abs(imageData.Pitch)];
        Marshal.Copy(imageData.Buffer, data, 0, data.Length);
        // Write this function yourself. They're both enums so a simple switch-case should do.
        // GRAY probably needs to be seen as indexed 8bpp; then you need to give a generated
        // 256-entry black-to-white colour fade palette to BuildImage in the next step.
        PixelFormat format = ConvertPixelformat(imageData.Format);
        // The function I linked in the description.
        Bitmap image = BuildImage(data, imageData.Width, imageData.Height, imageData.Pitch, format, null, null);
        // These will need conversion from ppi to dpi. Google it yourself.
        bitmap.SetResolution(imageData.ResolutionX, imageData.ResolutionY);
        return bitmap;
    }
