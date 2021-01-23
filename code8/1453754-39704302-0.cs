    Bitmap clone = new Bitmap(resized.Width, resized.Height,
        System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    using (Graphics gr = Graphics.FromImage(clone)) {
        gr.DrawImage(resized, new Rectangle(0, 0, clone.Width, clone.Height));
    }
