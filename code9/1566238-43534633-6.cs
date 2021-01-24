    public static byte[] BitmapSourceToByteArray(BitmapSource bitmap)
    {
        var encoder = new PngBitmapEncoder(); // or any other BitmapEncoder
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = new MemoryStream())
        {
            encoder.Save(stream);
            return stream.ToArray();
        }
    }
