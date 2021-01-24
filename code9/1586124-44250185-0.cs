    public byte[] SubArray(byte[] Data, int Offset, int Len)
    {
        byte[] Result = new byte[Len];
        Buffer.BlockCopy(Data, Offset, Result, 0, Len);
        return Result;
    }
