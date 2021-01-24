    /// <summary>
    /// Copies the given image to the clipboard as PNG, DIB and standard Bitmap format.
    /// </summary>
    /// <param name="image">Image to put on the clipboard.</param>
    /// <param name="imageNoTr">Optional specifically nontransparent version of the image to put on the clipboard.</param>
    /// <param name="data">Clipboard data object to put the image into. Might already contain other stuff. Leave null to create a new one.</param>
    public static void SetClipboardImage(Bitmap image, Bitmap imageNoTr, DataObject data)
    {
        Clipboard.Clear();
        if (data == null)
            data = new DataObject();
        if (imageNoTr == null)
            imageNoTr = image;
        using (MemoryStream pngMemStream = new MemoryStream())
        using (MemoryStream dibMemStream = new MemoryStream())
        {
            // As standard bitmap, without transparency support
            data.SetData(DataFormats.Bitmap, true, imageNoTr);
            // As PNG. Gimp will prefer this over the other two.
            image.Save(pngMemStream, ImageFormat.Png);
            data.SetData("PNG", false, pngMemStream);
            // As DIB. This is (wrongly) accepted as ARGB by many applications.
            Byte[] dibData = ConvertToDib(image);
            dibMemStream.Write(dibData, 0, dibData.Length);
            data.SetData(DataFormats.Dib, false, dibMemStream);
            // The 'copy=true' argument means the MemoryStreams can be safely disposed after the operation.
            Clipboard.SetDataObject(data, true);
        }
    }
        
    /// <summary>
    /// Converts the image to Device Independent Bitmap format of type BI_BITFIELDS.
    /// This is (wrongly) accepted by many applications as containing transparency,
    /// so I'm abusing it for that.
    /// </summary>
    /// <param name="image">Image to convert to DIB</param>
    /// <returns>The image converted to DIB, in bytes.</returns>
    public static Byte[] ConvertToDib(Image image)
    {
        Byte[] bm32bData;
        Int32 width = image.Width;
        Int32 height = image.Height;
        // Ensure image is 32bppARGB by painting it on a new 32bppARGB image.
        using (Bitmap bm32b = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb))
        {
            using (Graphics gr = Graphics.FromImage(bm32b))
                gr.DrawImage(image, new Rectangle(0, 0, bm32b.Width, bm32b.Height));
            // Bitmap format has its lines reversed.
            bm32b.RotateFlip(RotateFlipType.Rotate180FlipX);
            Int32 stride;
            bm32bData = ImageUtils.GetImageData(bm32b, out stride);
        }
        // BITMAPINFOHEADER struct for DIB.
        Int32 hdrSize = 0x28;
        Byte[] headerBytes = new Byte[hdrSize];
        //Int32 biSize;
        ArrayUtils.WriteIntToByteArray(headerBytes, 0x00, 4, true, (UInt32)hdrSize);
        //Int32 biWidth;
        ArrayUtils.WriteIntToByteArray(headerBytes, 0x04, 4, true, (UInt32)width);
        //Int32 biHeight;
        ArrayUtils.WriteIntToByteArray(headerBytes, 0x08, 4, true, (UInt32)height);
        //Int16 biPlanes;
        ArrayUtils.WriteIntToByteArray(headerBytes, 0x0C, 2, true, 1);
        //Int16 biBitCount;
        ArrayUtils.WriteIntToByteArray(headerBytes, 0x0E, 2, true, 32);
        //BITMAPCOMPRESSION biCompression = BITMAPCOMPRESSION.BI_BITFIELDS;
        ArrayUtils.WriteIntToByteArray(headerBytes, 0x10, 4, true, 3);
        //Int32 biSizeImage;
        ArrayUtils.WriteIntToByteArray(headerBytes, 0x14, 4, true, (UInt32)bm32bData.Length);
        //Int32 biXPelsPerMeter = 0;
        //Int32 biYPelsPerMeter = 0;
        //Int32 biClrUsed = 0;
        //Int32 biClrImportant = 0;
        Byte[] fullImage = new Byte[hdrSize + 12 + bm32bData.Length];
        Array.Copy(headerBytes, 0, fullImage, 0, hdrSize);
        // The aforementioned "BITFIELDS": bit masks applied to the Int32 pixel value to get the R, G and B values.
        ArrayUtils.WriteIntToByteArray(fullImage, hdrSize + 0, 4, true, 0x00FF0000);
        ArrayUtils.WriteIntToByteArray(fullImage, hdrSize + 4, 4, true, 0x0000FF00);
        ArrayUtils.WriteIntToByteArray(fullImage, hdrSize + 8, 4, true, 0x000000FF);
        Array.Copy(bm32bData, 0, fullImage, hdrSize + 12, bm32bData.Length);
        return fullImage;
    }
