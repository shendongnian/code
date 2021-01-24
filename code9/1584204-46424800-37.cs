    /// <summary>
    /// Retrieves an image from the given clipboard data object, in the order PNG, DIB, Bitmap, Image object.
    /// </summary>
    /// <param name="retrievedData">The clipboard data.</param>
    /// <returns>The extracted image, or null if no supported image type was found.</returns>
    public static Bitmap GetClipboardImage(DataObject retrievedData)
    {
        Bitmap clipboardimage = null;
        // Order: try PNG, move on to try 32-bit ARGB DIB, then try the normal Bitmap and Image types.
        if (retrievedData.GetDataPresent("PNG"))
        {
            MemoryStream png_stream = retrievedData.GetData("PNG") as MemoryStream;
            if (png_stream != null)
                using (Bitmap bm = new Bitmap(png_stream))
                    clipboardimage = ImageUtils.CloneImage(bm);
        }
        if (clipboardimage == null && retrievedData.GetDataPresent(DataFormats.Dib))
        {
            MemoryStream dib = retrievedData.GetData(DataFormats.Dib) as MemoryStream;
            if (dib != null)
                clipboardimage = ImageFromClipboardDib(dib.ToArray());
        }
        if (clipboardimage == null && retrievedData.GetDataPresent(DataFormats.Bitmap))
            clipboardimage = new Bitmap(retrievedData.GetData(DataFormats.Bitmap) as Image);
        if (clipboardimage == null && retrievedData.GetDataPresent(typeof(Image)))
            clipboardimage = new Bitmap(retrievedData.GetData(typeof(Image)) as Image);
        return clipboardimage;
    }
    public static Bitmap ImageFromClipboardDib(Byte[] dibBytes)
    {
        if (dibBytes == null || dibBytes.Length < 4)
            return null;
        try
        {
            Int32 headerSize = (Int32)ArrayUtils.ReadIntFromByteArray(dibBytes, 0, 4, true);
            // Only supporting 40-byte DIB from clipboard
            if (headerSize != 40)
                return null;
            Byte[] header = new Byte[40];
            Array.Copy(dibBytes, header, 40);
            Int32 imageIndex = headerSize;
            Int32 width = (Int32)ArrayUtils.ReadIntFromByteArray(header, 0x04, 4, true);
            Int32 height = (Int32)ArrayUtils.ReadIntFromByteArray(header, 0x08, 4, true);
            Int16 planes = (Int16)ArrayUtils.ReadIntFromByteArray(header, 0x0C, 2, true);
            Int16 bitCount = (Int16)ArrayUtils.ReadIntFromByteArray(header, 0x0E, 2, true);
            Int32 compression = (Int32)ArrayUtils.ReadIntFromByteArray(header, 0x10, 4, true);
            // Not dealing with non-standard formats
            if (planes != 1 || (compression != 0 && compression != 3))
                return null;
            PixelFormat fmt;
            switch (bitCount)
            {
                case 32:
                    fmt = PixelFormat.Format32bppRgb;
                    break;
                case 24:
                    fmt = PixelFormat.Format24bppRgb;
                    break;
                case 16:
                    fmt = PixelFormat.Format16bppRgb555;
                    break;
                default:
                    return null;
            }
            if (compression == 3)
                imageIndex += 12;
            if (dibBytes.Length < imageIndex)
                return null;
            Byte[] image = new Byte[dibBytes.Length - imageIndex];
            Array.Copy(dibBytes, imageIndex, image, 0, image.Length);
            // Classic stride: fit within blocks of 4 bytes.
            Int32 stride = (((((bitCount * width) + 7) / 8) + 3) / 4) * 4;
            if (compression == 3)
            {
                UInt32 redMask = ArrayUtils.ReadIntFromByteArray(dibBytes, headerSize + 0, 4, true);
                UInt32 greenMask = ArrayUtils.ReadIntFromByteArray(dibBytes, headerSize + 4, 4, true);
                UInt32 blueMask = ArrayUtils.ReadIntFromByteArray(dibBytes, headerSize + 8, 4, true);
                // Fix for the undocumented use of 32bppARGB disguised as BI_BITFIELDS. Despite lacking an alpha bit field,
                // the alpha bytes are still filled in, without any header indication of alpha usage.
                // Pure 32-bit RGB: check if a switch to ARGB can be made by checking for non-zero alpha.
                // Admitted, this may give a mess if the alpha bits simply aren't cleared, but why the hell wouldn't it use 24bpp then?
                if (bitCount == 32 && redMask == 0xFF0000 && greenMask == 0x00FF00 && blueMask == 0x0000FF)
                {
                    // Stride is always a multiple of 4; no need to take it into account for 32bpp.
                    for (Int32 pix = 3; pix < image.Length; pix += 4)
                    {
                        // 0 can mean transparent, but can also mean the alpha isn't filled in, so only check for non-zero alpha,
                        // which would indicate there is actual data in the alpha bytes.
                        if (image[pix] == 0)
                            continue;
                        fmt = PixelFormat.Format32bppPArgb;
                        break;
                    }
                }
                else
                    // Could be supported with a system that parses the colour masks,
                    // but I don't think the clipboard ever uses these anyway.
                    return null;
            }
            Bitmap bitmap = ImageUtils.BuildImage(image, width, height, stride, fmt, null, null);
            // This is bmp; reverse image lines.
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            return bitmap;
        }
        catch
        {
            return null;
        }
    }
