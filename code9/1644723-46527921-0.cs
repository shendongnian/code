    [DllImport("LibName", CallingConvention = CallingConvention.Cdecl)]
    static extern void ProcessData(IntPtr data, int size);
    
    public unsafe void ProcessData(byte[] data, int size)
    {
        //Pin Memory
        fixed (byte* p = data)
        {
            ProcessData((IntPtr)p, size);
        }
    }
