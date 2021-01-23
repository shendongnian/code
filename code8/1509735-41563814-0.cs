    public static string ToHex(byte[] bytes)
    {
        char[] c = new char[bytes.Length * 2];
        byte b;
        for (int bx = 0, cx = c.Length - 1; bx < bytes.Length; ++bx)
        {
            b = ((byte)(bytes[bx] & 0x0F));
            c[cx--] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
            b = ((byte)(bytes[bx] >> 4));
            c[cx--] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
        }
        return new string(c);
    }
    public static byte[] StringToByteArrayFastest(string hex)
    {
        if (hex.Length % 2 == 1) throw new Exception("The binary key cannot have an odd number of digits");
        byte[] arr = new byte[hex.Length >> 1];
        for (int i = 0, j = arr.Length - 1; i < arr.Length; ++i)
        {
            arr[j--] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
        }
        return arr;
    }
