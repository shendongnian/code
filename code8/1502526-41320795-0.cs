    public static byte[] HexStringToByteArray(string s)
    {
        int len = s.Length;
        byte[] data = new byte[len/ 2];
        for (int i = 0; i < len; i += 2)
        {
            data[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
        }
        return data;
    }
