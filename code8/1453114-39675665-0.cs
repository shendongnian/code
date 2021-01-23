    RectangleF FitToBox(RectangleF scr, RectangleF dest, bool centered)
    {
        var ratioX = (double)dest.Width / scr.Width;
        var ratioY = (double)dest.Height / scr.Height;
        var ratio = Math.Min(ratioX, ratioY);
        var newWidth = (int)(scr.Width * ratio);
        var newHeight = (int)(scr.Height * ratio);
        if (!centered)
            return new RectangleF(0, 0, newWidth, newHeight);
        else
            return new RectangleF((dest.Width - newWidth) / 2, 
                                 (dest.Height - newHeight) / 2, newWidth, newHeight);
    }
