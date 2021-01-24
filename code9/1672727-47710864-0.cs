    Rectangle ConvertToLargeRect(Rectangle smallRect, Size largeImageSize, Size smallImageSize)
    {
        double xScale = (double)largeImageSize.Width / smallImageSize.Width;
        double yScale = (double)largeImageSize.Height / smallImageSize.Height;    
        int x = (int)(smallRect.X * xScale + 0.5);
        int y = (int)(smallRect.Y * yScale + 0.5);
        int right = (int)(smallRect.Right * xScale + 0.5);
        int bottom = (int)(smallRect.Bottom * yScale + 0.5);
        return new Rectangle(x, y, right - x, bottom - y);
    }
