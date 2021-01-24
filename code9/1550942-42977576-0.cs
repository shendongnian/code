    [FieldOffset(8)]
    public IntPtr _data;
    public byte[] GetData()
    {
        // YOU MUST FREE _data C-side! You can't use
        // C++ delete C#-side
        var bytes = new byte[5];
        Marshal.Copy(_data, bytes, 0, bytes.Length);
        return bytes;
    }
