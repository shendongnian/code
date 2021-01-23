    public Color GetTextColor(Bitmap bitmap)
    {
        var y = bitmap.Height/2;
        var startingColor = bitmap.GetPixel(0, y);
        for (int x = 1; x < bitmap.Width; x++)
        {
            var thisColor = bitmap.GetPixel(x, y);
            if (thisColor != startingColor)
                return thisColor;
        }
        return null;
    }
