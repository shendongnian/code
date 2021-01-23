    [StructLayout(LayoutKind.Sequential)]
    public struct application_request
    {
        public UInt32 query;
    
        public IntPtr client;
    
        [MarshalAs(UnmanagedType.I1)]
        public bool isAuthenticated;
    
        [MarshalAs(UnmanagedType.I1)]
        public bool isGuest; 
    }
