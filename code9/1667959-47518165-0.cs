    [DllImport("1.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Func(ref int x);
    static void Main(string[] args)
    {
        int value = 0;
        GCHandle handle = GCHandle.Alloc(value, GCHandleType.Pinned);
        Func(ref value);
        handle.Free();
        Console.WriteLine(value);
    }
