    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EXT_STRUCT
    {
        public byte innAttr1;
        public byte innAttr2;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet=CharSet.Ansi)]
    public struct STRUCT
    {
        public EXT_STRUCT extAttr1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string str1;
        public ulong attrLong; // That was uint
    
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string str2;
    
        public EXT_STRUCT extAttr2;
    }
