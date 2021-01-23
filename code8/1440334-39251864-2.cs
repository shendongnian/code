    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CtrlWord1
    {
        [MarshalAs(UnmanagedType.I1)]  // marshal as a 1-byte signed int, not a 4-byte BOOL
        public bool a1;
        // etc.
    }
