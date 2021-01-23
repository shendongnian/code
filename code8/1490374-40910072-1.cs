    bool tile_preset = false;
    for(int b = 0; b < temp.Height; b++)
    {
        for(int a = 0; a < temp.Width; a++)
        {
            Color c = temp.GetPixel(a, b);
            tile_preset |= (c.A != 0 || c.R != 0 || c.G != 0 || c.B != 0);
        }
    }
