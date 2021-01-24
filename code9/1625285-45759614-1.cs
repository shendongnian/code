    private void LoadImageMap(Bitmap value)
    {
        for (int col = 0; col < value.Width; col++)
        {
            for (int row = 0; row < value.Height; row++)
            {
                var color = value.GetPixel(col, row);
            }
        }
    }
