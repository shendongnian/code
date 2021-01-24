    Bitmap image;
    using (Bitmap tmpImage = new Bitmap(filepath))
    {
        image = new Bitmap(tmpImage.Width, tmpImage.Height, PixelFormat.Format32bppArgb);
        using (Graphics gr = Graphics.FromImage(image))
            gr.DrawImage(tmpImage, new Rectangle(0, 0, image.Width, image.Height));
    }
    // Bitmap "image" is now ready to use.
