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
