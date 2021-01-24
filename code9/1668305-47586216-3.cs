    public static void SetBuffer(this ushort value, byte[] arr, int beginIndex)
    {
        arr[beginIndex] = (byte)(value >> 8);
        arr[beginIndex + 1] = (byte)value;
    }
    
    public static void SetBuffer(this uint value, byte[] arr, int beginIndex)
    {
        arr[beginIndex] = (byte)(value >> 24);
        arr[beginIndex + 1] = (byte)(value >> 16);
        arr[beginIndex + 2] = (byte)(value >> 8);
        arr[beginIndex + 3] = (byte)value;
    }
    
    public static void SetBuffer(this int value, byte[] arr, int beginIndex)
    {
        arr[beginIndex] = (byte)(value >> 24);
        arr[beginIndex + 1] = (byte)(value >> 16);
        arr[beginIndex + 2] = (byte)(value >> 8);
        arr[beginIndex + 3] = (byte)value;
    }
    
    public static void SetBuffer(this short value, byte[] arr, int beginIndex)
    {
        arr[beginIndex] = (byte)(value >> 8);
        arr[beginIndex + 1] = (byte)value;
    }
    
    public static void SetBuffer(this ulong value, byte[] arr, int beginIndex)
    {
        arr[beginIndex] = (byte)(value >> 56);
        arr[beginIndex + 1] = (byte)(value >> 48);
        arr[beginIndex + 2] = (byte)(value >> 40);
        arr[beginIndex + 3] = (byte)(value >> 32);
        arr[beginIndex + 4] = (byte)(value >> 24);
        arr[beginIndex + 5] = (byte)(value >> 16);
        arr[beginIndex + 6] = (byte)(value >> 8);
        arr[beginIndex + 7] = (byte)value;
    }
    
    public static void SetBuffer(this long value, byte[] arr, int beginIndex)
    {
        arr[beginIndex] = (byte)(value >> 56);
        arr[beginIndex + 1] = (byte)(value >> 48);
        arr[beginIndex + 2] = (byte)(value >> 40);
        arr[beginIndex + 3] = (byte)(value >> 32);
        arr[beginIndex + 4] = (byte)(value >> 24);
        arr[beginIndex + 5] = (byte)(value >> 16);
        arr[beginIndex + 6] = (byte)(value >> 8);
        arr[beginIndex + 7] = (byte)value;
    }
