    using (MemoryStream memStream = new MemoryStream())
    {
        using (MagickImage image = new MagickImage(byteArray))
        {
            image.Format = MagickFormat.Png;
            image.Write(memStream);
        }
        return System.Convert.ToBase64String(memStream.ToArray());
    }
