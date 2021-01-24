    public static byte[] AESDecrypt(byte[] data, ICryptoTransform transform)
    {
        using (MemoryStream output = new MemoryStream())
        {
            using (MemoryStream stream = new MemoryStream(data))
            using (CryptoStream cstream = new CryptoStream(stream, transform, CryptoStreamMode.Read))
            {
                cstream.CopyTo(output);
            }
            return output.ToArray();
        }
    }
