    Color[] colors = new Color[] {Color.Black, Color.White };
    ColorPalette pal = image.Palette;
    for(Int32 i = 0; i < pal.Entries.Length; i++)
    {
        Int32 foundIndex = ColorUtils.GetClosestPaletteIndexMatch(pal.Entries[i], palette);
        pal.Entries[i] = palette[foundIndex];
    }
    image.Palette = pal;
