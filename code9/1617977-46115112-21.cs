    public static Byte[] Convert32BitTo8Bit(Byte[] imageData, Int32 width, Int32 height, Color[] palette, ref Int32 stride)
    {
        if (stride < width * 4)
            throw new ArgumentException("Stride is smaller than one pixel line!", "stride");
        Byte[] newImageData = new Byte[width * height];
        for (Int32 y = 0; y < height; y++)
        {
            for (Int32 x = 0; x < width; x++)
            {
                Int32 inputOffs = y * stride + x * 4;
                Int32 outputOffs = y * width + x;
                // 32bppArgb: Order of the bytes is Alpha, Red, Green, Blue.
                // Since we're converting to a palette we ignore the alpha one.
                Color c = Color.FromArgb(255, imageData[inputOffs + 1], imageData[inputOffs + 2], imageData[inputOffs + 3]);
                // Match to palette index
                newImageData[outputOffs] = (Byte)ColorUtils.GetClosestPaletteIndexMatch(c, palette, null);
            }
        }
        stride = width;
        return newImageData;
    }
