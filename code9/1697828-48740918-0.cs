    [DllExport("combinewords", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.LPWStr)] // matches python's c_wchar_p
    public static string CombineWords(object obj) // object matches python's VARIANT
    {
        var array = (object[])obj; // if obj is an array, it will always be an array of object
        return string.Join(", ", array);
    }
