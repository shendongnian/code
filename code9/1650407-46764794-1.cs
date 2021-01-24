    public static byte[] StrToByteArray(string hexValue) {
        return Enumerable.Range(0, hexValue.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hexValue.Substring(x, 2), 16))
                     .ToArray();
    }
