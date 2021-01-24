    [DllExport("printstrings", CallingConvention = CallingConvention.Cdecl)]
    public static void PrintStrings(ref object obj)
    {
        obj = new string[] { "hello", "world" };
    }
