    public static byte[] ValueToBigEndian(dynamic data)
    {
        byte[] bytes = BitConverter.GetBytes(data);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        return bytes;
    }
