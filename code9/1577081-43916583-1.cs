    public unsafe int Get4Bytes(byte[] bytes, int index)
    {
        fixed (byte* b = &bytes[index])
        {
            var v = (int*)b;
            return *v;
        }
    }
