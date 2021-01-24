    public static byte[] ArrayCopy(byte[] source, int length, int start = 0) {
        var dest = new byte[length];                                          
        Array.Copy(source, start, dest, 0, length);                           
        return dest;                                                          
    }                                                                         
