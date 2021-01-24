    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct Cam
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ip;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string login;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string pass;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
    }
        
