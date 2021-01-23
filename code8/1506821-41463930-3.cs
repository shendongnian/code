    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct CommonDialogBaseParam {
        public UIntPtr size;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=36)]
        public byte[] reserved;
        public uint magic;
    }
