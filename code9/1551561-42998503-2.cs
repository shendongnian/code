    byte[] data;
    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(imagebox.Source as BitmapImage));
    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
    {
        encoder.Save(ms);
        data = ms.ToArray();
    }
    if (data != null)
    { 
        const string filename = @"c:\test\1.jpg";
        System.IO.File.WriteAllBytes(filename, data);
    }
