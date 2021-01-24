    public static Bitmap PaintOn32bpp(Image image, Color? transparencyFillColor)
    {
        Bitmap bp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
        using (Graphics gr = Graphics.FromImage(bp))
        {
            if (transparencyFillColor.HasValue)
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, transparencyFillColor.Value)))
                    gr.FillRectangle(myBrush, new Rectangle(0, 0, image.Width, image.Height));
            gr.DrawImage(image, new Rectangle(0, 0, bp.Width, bp.Height));
        }
        return bp;
    }
