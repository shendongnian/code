    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct EKIDinfo
    {
        public System.Int16 usbNo;      //<--- changed
        public System.Int16 printerID;  //<--- changed
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string serialNo;
        public ushort mediaType;
    }
