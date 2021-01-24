    Bitmap PadCropImage(Bitmap original)
    {
        if (original.Width == 500 && original.Height == 500)
            return original;
        if (original.Width > 500 && original.Height > 500)
        {
            int x = (original.Width - 500) / 2;
            int y = (original.Height - 500) / 2;
            return original.Clone(new Rectangle(x, y, 500, 500), original.PixelFormat);
        }
        Bitmap square = new Bitmap(500, 500);
        var g = Graphics.FromImage(square);
        if (original.Width > 500)
        {
            int x = (original.Width - 500) / 2;
            int y = (500 - original.Height) / 2;
            g.DrawImageUnscaled(original, -x, y);
        }
        else if (original.Height > 500)
        {
            int x = (500 - original.Width) / 2;
            int y = (original.Height - 500) / 2;
            g.DrawImageUnscaled(original, x, -y);
        }
        else
        {
            int x = (500 - original.Width) / 2;
            int y = (500 - original.Height) / 2;
            g.DrawImageUnscaled(original, x, y);
        }
        return square;
    }
