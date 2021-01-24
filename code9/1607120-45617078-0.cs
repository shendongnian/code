    using (var fs = new MemoryStream(fileAttachment.Content))
    {
        Image image = System.Drawing.Image.FromStream(fs);
        if (!(image.Width == 190 && image.Height == 45) )
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
             ...
