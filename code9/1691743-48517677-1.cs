    /// <summary>
    /// Gets the raw bytes from an image.
    /// </summary>
    /// <param name="sourceImage">The image to get the bytes from.</param>
    /// <param name="stride">Stride of the retrieved image data.</param>
    /// <returns>The raw bytes of the image</returns>
    public static Byte[] GetImageData(Bitmap sourceImage, out Int32 stride)
    {
        BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.ReadOnly, sourceImage.PixelFormat);
        stride = sourceData.Stride;
        Byte[] data = new Byte[stride * sourceImage.Height];
        Marshal.Copy(sourceData.Scan0, data, 0, data.Length);
        sourceImage.UnlockBits(sourceData);
        return data;
    }
