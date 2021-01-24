    const string filename = "longname_®.png_thumbnail.jpg";
    // You can also use Encoding.Default, as that should return Windows-1251 on your machine,
    // as you obviously have the 1251 set as the default legacy Ansi encoding.
    Encoding encoding = Encoding.GetEncoding("Windows-1251");
    byte[] bytes = encoding.GetBytes(filename);
    string encoded = "";
    for (int i = 0; i < bytes.Length; i++)
    {
        char c = (char)bytes[i];
        if (c >= 0x80)
        {
            // URL-encode all characters in range 128-255
            encoded += Uri.HexEscape(c);
        }
        else
        {
            // URL-encode only reserved characters in range 0-127
            encoded += Uri.EscapeDataString(new string(c, 1));
        }
    }
