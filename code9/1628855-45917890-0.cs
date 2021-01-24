    // [MarshalAs(UnmanagementType.ByValTStr, SizeConst=32)]
    // public string name;
    [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.ByValTStr, SizeConst=32)]
    public byte[] name;
    string str = System.Text.Encoding.GetEncoding("Shift_JIS").GetString(name);
