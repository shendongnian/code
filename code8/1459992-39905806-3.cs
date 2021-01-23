    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int memcmp(IntPtr b1, IntPtr b2, int count);
    static bool SafeMemCmp(byte[] arr1, byte[] arr2)
    {
        var a = Marshal.AllocHGlobal(arr1.Length);
        Marshal.Copy(arr1, 0, a, arr1.Length);
        var b = Marshal.AllocHGlobal(arr2.Length);
        Marshal.Copy(arr2, 0, b, arr2.Length);
        try
        {
            return memcmp(a, b, 5000) == 0;
        }
        finally
        {
            Marshal.FreeHGlobal(a);
            Marshal.FreeHGlobal(b);
        }
    }
