    [DllExport("GetStrings", CallingConvention = CallingConvention.Cdecl)]
    public static void GetStrings([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]string[] MyStrings, int size)
    {
        foreach(var s in MyStrings)
        {
            MessageBox.Show(s);
        }
    }
