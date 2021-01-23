    Image yourImage = ...
    
    Bitmap bitmap = new Bitmap(yourImage);
    int whiteColorCount = 0;
    int blackColorCount = 0;
    for (int i = 0; i < bitmap.Width; i++)
    {
        for (int c = 0; c < bitmap.Height; c++)
        {
            int pixelHexColor = bitmap.GetPixel(i, c).ToArgb();
            if (pixelHexColor == Color.White.ToArgb())
            {
                whiteColorCount++;
            }
            else if (pixelHexColor == Color.Black.ToArgb())
            {
                blackColorCount++;
            }
        }
    }
    long totalPixelCount = bitmap.Width * bitmap.Height;
    double whitePixelPercent = whiteColorCount / (totalPixelCount / 100.0);
    double blackPixelPercent = blackColorCount / (totalPixelCount / 100.0);
    double otherPixelPercent = 100.0 - whitePixelPercent - blackPixelPercent;
