    public static Byte[] Convert32BitTo8Bit(Byte[] imageData, Int32 width, Int32 height, Color[] palette, ref Int32 stride)
    {
        if (stride < width * 4)
            throw new ArgumentException("Stride is smaller than one pixel line!", "stride");
        Byte[] newImageData = new Byte[width * height];
        for (Int32 y = 0; y < height; y++)
        {
            Int32 inputOffs = y * stride;
            Int32 outputOffs = y * width;
            for (Int32 x = 0; x < width; x++)
            {
                // 32bppArgb: Order of the bytes is Alpha, Red, Green, Blue, but
                // since this is actually in the full 4-byte value read from the offset,
                // and this value is considered little-endian, they are actually in the
                // order BGRA. Since we're converting to a palette we ignore the alpha
                // one and just give RGB.
                Color c = Color.FromArgb(imageData[inputOffs + 2], imageData[inputOffs + 1], imageData[inputOffs]);
                // Match to palette index
                newImageData[outputOffs] = (Byte)ColorUtils.GetClosestPaletteIndexMatch(c, palette, null);
                inputOffs += 4;
                outputOffs++;
            }
        }
        stride = width;
        return newImageData;
    }
