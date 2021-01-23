    using (MemoryStream ms = new MemoryStream())
    {
        Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        ActualByte = ms.ToArray();
    }
