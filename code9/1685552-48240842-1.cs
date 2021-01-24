    /// <summary>
    /// Defines the printer default settings like the access rights
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct PrinterDefaults
    {
        public IntPtr pDataType;
        public IntPtr pDevMode;
        public PrinterAccess DesiredAccess;
    }
    /// <summary>
    /// Stores the port data for deleting an existing printer port
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct DeletePort
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string sztPortName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 49)]
        public string sztName;
        public UInt32 dwVersion;
        public UInt32 dwReserved;
    }
    /// <summary>
    /// Specifies identifiers to indicate the printer access
    /// </summary>
    internal enum PrinterAccess
    {
        ServerAdmin = 0x01,
        ServerEnum = 0x02,
        PrinterAdmin = 0x04,
        PrinterUse = 0x08,
        JobAdmin = 0x10,
        JobRead = 0x20,
        StandardRightsRequired = 0x000f0000,
        PrinterAllAccess = (StandardRightsRequired | PrinterAdmin | PrinterUse)
    }
