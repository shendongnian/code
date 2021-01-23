    public static byte[] ValueToBigEndian<T>(T data)
    {
        byte[] bytes;
        // We want to use big endian
        if (BitConverter.IsLittleEndian)
        {
            bytes = GetBytesTemplated(data);
            Array.Reverse(bytes);
        }
        else
        {
            // Host is big endian already
            bytes = GetBytesTemplated(data);
        }
        return bytes;
    }
