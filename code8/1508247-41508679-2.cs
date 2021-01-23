    using (var ms = new System.IO.MemoryStream(BData))
    {
        System.Drawing.Image.Image image = System.Drawing.Image.FromStream(ms);
        image.Save(@"test.png");
    }
