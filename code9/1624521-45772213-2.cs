    [Guid("xx")]
    [ComVisible(true)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct StudentItem
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string Type;
        public DateTime Week;
        public int Study;
    }
