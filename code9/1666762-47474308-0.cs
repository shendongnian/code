    string base64 = "";
    using (MemoryStream stream = new MemoryStream())
    {
        u.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        base64 = Convert.ToBase64String(stream.ToArray());
    }
