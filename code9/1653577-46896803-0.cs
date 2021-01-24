    public static byte[] HexStringToByteArray(string hexString)
    {
        MemoryStream stream = new MemoryStream(hexString.Length / 2);
        for (int i = 0; i < hexString.Length; i += 2)
        {
            stream.WriteByte(byte.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
        }
        return stream.ToArray();
    }
