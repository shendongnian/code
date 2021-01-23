    var fontName = "Segoe UI";
    using (var factory = new Factory(FactoryType.Shared))
    {
        using (var fontCollection = factory.GetSystemFontCollection(true))
        {
            int familyIndex;
            fontCollection.FindFamilyName(fontName, out familyIndex);
            using (var fontFamily = fontCollection.GetFontFamily(familyIndex))
            {
                var font = fontFamily.GetFont(0);
                using (var fontface = new FontFace(font))
                {
                    int[] codes = { 0x41, 0x6f, 0x7c, 0xc2aa, 0xD7A3 };
                    var results = fontface.GetGlyphIndices(codes);
                    for (int i = 0; i < codes.Length - 1; i++)
                    {
                        if (results[i] > 0)
                        {
                            Debug.WriteLine("Contains the unicode character " + codes[i]);
                        }
                        else
                        {
                            Debug.WriteLine("Does not contain the unicode character " + codes[i]);
                        }
                    }
                }
            }
        }
    }
