    private static Byte[] PNG_IDENTIFIER = {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A};
    private static Byte[] PNG_BLANK = { 0x08, 0xD7, 0x63, 0x60, 0x00, 0x00, 0x00, 0x02, 0x00, 0x01};
    /// <summary>
    /// Creates a custom-sized color palette by creating an empty png with a limited palette and extracting its palette.
    /// </summary>
    /// <param name="colors">The colors to convert into a palette.</param>
    /// <returns>A color palette containing the given colors.</returns>
    public static ColorPalette GetPalette(Color[] colors)
    {
        // Silliest idea ever, but it works.
        const Int32 chunkExtraLen = 0x0C;
        Int32 lenPng = PNG_IDENTIFIER.Length;
        const Int32 lenHdr = 0x0D;
        Int32 lenPal = Math.Min(colors.Length, 0x100) * 3;
        Int32 lenData = PNG_BLANK.Length;
        Int32 fullLen = lenPng + lenHdr + chunkExtraLen + lenPal + chunkExtraLen + lenData + chunkExtraLen + chunkExtraLen;
        Int32 offset = 0;
        Byte[] emptyPng = new Byte[fullLen];
        Array.Copy(PNG_IDENTIFIER, 0, emptyPng, 0, PNG_IDENTIFIER.Length);
        offset += lenPng;
        Byte[] header = new Byte[lenHdr];
        // Width: 1
        header[3] = 1;
        // Heigth: 1
        header[7] = 1;
        // Color depth: 8
        header[8] = 8;
        // Color type: paletted
        header[9] = 3;
        WritePngChunk(emptyPng, offset, "IHDR", header);
        offset += lenHdr + chunkExtraLen;
        // Don't even need to fill this in. We just need the size.
        Byte[] palette = new Byte[lenPal];
        WritePngChunk(emptyPng, offset, "PLTE", palette);
        offset += lenPal + chunkExtraLen;
        WritePngChunk(emptyPng, offset, "IDAT", PNG_BLANK);
        offset += lenData + chunkExtraLen;
        WritePngChunk(emptyPng, offset, "IEND", new Byte[0]);
        using (MemoryStream ms = new MemoryStream(emptyPng))
        // By doing this afterwards we can ensure the alpha is correct too; the PLTE chunk
        // is RGB without alpha, and if there's a tRNS chunk to add alpha, the framework will
        // convert the image to 32 bit for some bizarre reason.
        using (Bitmap loadedImage = new Bitmap(ms))
        {
            ColorPalette pal = loadedImage.Palette;
            for (Int32 i = 0; i < pal.Entries.Length; i++)
                pal.Entries[i] = colors[i];
            return pal;
        }
    }
