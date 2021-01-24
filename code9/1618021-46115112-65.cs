    Color[] colors = new Color[] {Color.Black, Color.White };
    Bitmap newImage = ConvertToColors(image, colors);
    ColorPalette pal = newImage.Palette;
    pal.Entries[0] = Color.Blue;
    pal.Entries[1] = Color.Yellow;
    newImage.Palette = pal;
