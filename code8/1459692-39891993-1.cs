    Image yourImage = ...
    
    Bitmap bitmap = new Bitmap(yourImage);
    int whiteColorCount = 0;
    int blackColorCount = 0;
    for(int i = 0; i < bitmap.Width; i++)
    {
        for(int c = 0; c < bitmap.Height; c++)
        {
            if(bitmap.GetPixel(i, c) == Color.White)
            {
                whiteColorCount++;
            }
            else if(bitmap.GetPixel(i, c) == Color.Black)
            {
                blackColorCount++;
            }
        }
    }    
    
    double whitePixelPercent = whiteColorCount / (bitmap.Height * bitmap.Width / 100.0);
    double blackPixelPercent = blackColorCount / (bitmap.Height * bitmap.Width / 100.0);
    double otherPixelPercent = 100.0 - whitePixelPercent - blackPixelPercent;
