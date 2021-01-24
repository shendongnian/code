    using (Stream stream = new MemoryStream(fcr.FileContents))
    {
        stream.Position = 0;
        System.Drawing.Image img = System.Drawing.Image.FromStream(stream, true, true);
    }
