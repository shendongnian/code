    internal static string ByteArrayToHex(this byte[] bytes)
    {
        StringBuilder builder = new StringBuilder(bytes.Length * 2);
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("X2"));
        }
        return builder.ToString();
    }
