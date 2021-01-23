    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Configs
    {
        public int myInt;
        [MarshalAs(UnmanagedType.R4)]
        public float myFloat;
        [MarshalAs(UnmanagedType.U1)]
        public bool flag;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string group;
    }
