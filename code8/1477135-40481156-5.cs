    public static byte[] ValueToBigEndian<T>(T data) where T : struct
    {
        byte[] bytes = GetBytesTemplated(data);
        // We want to use big endian
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        return bytes;
    }
