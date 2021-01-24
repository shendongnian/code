    StructLayout(LayoutKind.Sequential)]
    internal struct RID_DEVICE_INFO_HID
    {
        [MarshalAs(UnmanagedType.U4)]
        public int dwVendorId;
        [MarshalAs(UnmanagedType.U4)]
        public int dwProductId;
        [MarshalAs(UnmanagedType.U4)]
        public int dwVersionNumber;
        [MarshalAs(UnmanagedType.U2)]
        public ushort usUsagePage;
        [MarshalAs(UnmanagedType.U2)]
        public ushort usUsage;
    }
