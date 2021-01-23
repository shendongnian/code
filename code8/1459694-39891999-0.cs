        // Return the number of matching pixels.
    private int CountPxl(Bitmap bmap, Color yourColor)
    {
    // Loop through the pixels.
    int matches = 0;
    for (int y = 0; y < bmap.Height; y++)
    {
    for (int x = 0; x < bmap.Width; x++)
    {
    if (bmap.GetPixel(x, y) == yourColor) matches++;
    }
    }
    return matches;
    }
