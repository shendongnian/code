    var edit = new Bitmap(bm.Width, bm.Height);
    // ...
    using (Graphics imagesGraphics = Graphics.FromImage(edit))
    {
        // draw original
        // draw watermark
    }
    return edit;
