    [StructLayout(LayoutKind.Sequential)]
    public struct BoolStruct
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool a;
        [MarshalAs(UnmanagedType.U1)]
        public bool b;
        public float c;
    }
