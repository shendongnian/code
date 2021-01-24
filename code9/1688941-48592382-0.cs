    Byte[] bytes = File.ReadAllBytes(filename);
    Encoding encoding = null;
    String text = null;
    // Test UTF8 with BOM. This check can easily be copied and adapted
    // to detect many other encodings that use BOMs.
    UTF8Encoding encUtf8Bom = new UTF8Encoding(true, false);
    Byte[] pre = encUtf8Bom.GetPreamble();
    if (bytes.Length >= pre.Length && pre.SequenceEqual(bytes.Take(pre.Length)))
    {
        // UTF8 BOM found; use EncBom to decode.
        text = encUtf8Bom.GetString(bytes);
        encoding = encUtf8Bom;
    }
    if (encoding == null)
    {
        // test UTF-8 on strict encoding rules.
        // Note that on pure ASCII this will succeed as well, since valid ASCII
        // is automatically valid UTF-8.
        UTF8Encoding encUtf8NoBom = new UTF8Encoding(false, true);
        try
        {
            text = encUtf8NoBom.GetString(bytes);
            encoding = encUtf8NoBom;
        }
        catch(ArgumentException)
        {
            // Confirmed as not UTF-8!
            // This check can of course also be done on the BOM one
            // if you initialise encBom as "new UTF8Encoding(true, true)"
        }
    }
    // fall back to default ANSI encoding.
    if (encoding == null)
    {
        encoding = Encoding.GetEncoding("Windows-1252");
        text = encoding.GetString(bytes);
    }
