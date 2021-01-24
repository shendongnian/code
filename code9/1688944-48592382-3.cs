    Byte[] bytes = File.ReadAllBytes(filename);
    Encoding encoding = null;
    String text = null;
    // Test UTF8 with BOM. This check can easily be copied and adapted
    // to detect many other encodings that use BOMs.
    UTF8Encoding encUtf8Bom = new UTF8Encoding(true, true);
    Boolean couldBeUtf8 = true;
    Byte[] preamble = encUtf8Bom.GetPreamble();
    Int32 prLen = preamble.Length;
    if (bytes.Length >= prLen && preamble.SequenceEqual(bytes.Take(prLen)))
    {
        // UTF8 BOM found; use encUtf8Bom to decode.
        try
        {
            // Seems that despite being an encoding with preamble,
            // it doesn't actually skip said preamble when decoding...
            text = encUtf8Bom.GetString(bytes, prLen, bytes.Length - prLen);
            encoding = encUtf8Bom;
        }
        catch(ArgumentException)
        {
            // Confirmed as not UTF-8!
            couldBeUtf8 = false;
        }
    }
    // use boolean to skip this if it's already confirmed as incorrect UTF-8 decoding.
    if (couldBeUtf8 && encoding == null)
    {
        // test UTF-8 on strict encoding rules. Note that on pure ASCII this will
        // succeed as well, since valid ASCII is automatically valid UTF-8.
        UTF8Encoding encUtf8NoBom = new UTF8Encoding(false, true);
        try
        {
            text = encUtf8NoBom.GetString(bytes);
            encoding = encUtf8NoBom;
        }
        catch(ArgumentException)
        {
            // Confirmed as not UTF-8!
        }
    }
    // fall back to default ANSI encoding.
    if (encoding == null)
    {
        encoding = Encoding.GetEncoding("Windows-1252");
        text = encoding.GetString(bytes);
    }
