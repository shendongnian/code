    public static int getNonWhiteHeight(this Image img)
    {
        WriteableBitmap bmp = new WriteableBitmap(img.Source as BitmapImage);
        int topWhiteRowCount = 0;
        int width = bmp.PixelWidth;
        int height = bmp.PixelHeight;
    
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int pixel = bmp.Pixels[y * width + x];
                if (pixel != -1)
                {
                    topWhiteRowCount = y - 1;
                    goto returnLbl;
                } 
            }
        }
        returnLbl:
        return topWhiteRowCount >= 0 ? height - topWhiteRowCount : height;
    }
