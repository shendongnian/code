    public static bool IsNameBased(Guid id)
    {
        byte version = GetVersion(id);
        return version == 3 || version == 5;
    }
    public static byte GetVersion(Guid id)
    {
        byte[] byte_array = id.ToByteArray();
        byte version = (byte)(byte_array[7] >> 4);
        return version;
    }
