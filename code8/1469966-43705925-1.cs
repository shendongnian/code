    /// <summary>
    /// Generates a colour palette of the given bits per pixel containing a hue rotation of the given range.
    /// </summary>
    /// <param name="bpp">Bits per pixel of the image the palette is for.</param>
    /// <param name="blackOnZero">Replace the first colour on the palette with black.</param>
    /// <param name="addTransparentZero">Make the first colour on the palette transparent.</param>
    /// <param name="reverseGenerated">Reverse the generated range. This happens after the generating, and before the operations on the first index/</param>
    /// <param name="startHue">Start hue range. Value from 0 to 240.</param>
    /// <param name="endHue">End hue range. Value from 0 to 240. Must be higher then startHue.</param>
    /// <param name="inclusiveEnd">True to include the end hue in the palette. If you generate a full hue range, this can be set to False to avoid getting a duplicate red colour on it.</param>
    /// <returns>The generated palette, as array of System.Drawing.Color objects.</returns>
    public static Color[] GenerateRainbowPalette(Int32 bpp, Boolean blackOnZero, Boolean addTransparentZero, Boolean reverseGenerated, Int32 startHue, Int32 endHue, Boolean inclusiveEnd)
    {
        Int32 colors = 1 << bpp;
        Color[] pal = new Color[colors];
        Double step = (Double)(endHue - startHue) / (inclusiveEnd ? colors - 1 : colors);
        Double start = startHue;
        Double satValue = ColorHSL.SCALE;
        Double lumValue = 0.5 * ColorHSL.SCALE;
        for (Int32 i = 0; i < colors; i++)
        {
            if (i + 1 == colors)
            {
                i++;
                i--;
            }
            Double curStep =  start + step * i;
            pal[i] = new ColorHSL(curStep, satValue, lumValue);
        }
        if (reverseGenerated)
        {
            Color[] entries = pal.Reverse().ToArray();
            for (Int32 i = 0; i < pal.Length; i++)
                pal[i] = entries[i];
        }
        if (blackOnZero)
            pal[0] = Color.Black;
        // make color 0 transparent
        if (addTransparentZero)
            pal[0] = Color.FromArgb(0, pal[0]);
        return pal;
    }
