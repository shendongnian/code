    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CMSG
    {
        public Int32 l_id;
        public byte by_len;
        public byte by_msg_lost;
        public byte by_extended;
        public byte by_remote;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte aby_data[];
        public UInt32 ul_tstamp;
    };
