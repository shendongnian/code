    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct EKIDinfo
    {
        public short usbNo;
        public short printerID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string serialNo;
        public ushort mediaType;
    }
