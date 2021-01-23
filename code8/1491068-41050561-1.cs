    public static class NetShareUtilities
    {
        [DllImport("netapi32.dll")]
        private extern static int NetShareSetInfo([MarshalAs(UnmanagedType.LPWStr)] string servername, [MarshalAs(UnmanagedType.LPWStr)] string netname, int level, ref SHI1005_FLAGS buf, IntPtr parm_err);
        [DllImport("netapi32.dll")]
        private extern static int NetShareGetInfo([MarshalAs(UnmanagedType.LPWStr)] string servername, [MarshalAs(UnmanagedType.LPWStr)] string netname, int level, out IntPtr bufptr);
        [DllImport("netapi32.dll")]
        private static extern IntPtr NetApiBufferFree(IntPtr Buffer);
        public static SHI1005_FLAGS Get1005Flags(string serverName, string name)
        {
            IntPtr ptr;
            int err = NetShareGetInfo(serverName, name, 1005, out ptr);
            if (err != 0)
                throw new Win32Exception(err);
            var flags = (SHI1005_FLAGS)Marshal.ReadInt32(ptr);
            NetApiBufferFree(ptr);
            return flags;
        }
        public static void Set1005Flags(string serverName, string name, SHI1005_FLAGS flags)
        {
            // note: you need to have enough rights to call this
            int err = NetShareSetInfo(serverName, name, 1005, ref flags, IntPtr.Zero);
            if (err != 0)
                throw new Win32Exception(err);
        }
    }
    [Flags]
    public enum SHI1005_FLAGS
    {
        // note: all values are taken from LMERR.H
        SHI1005_FLAGS_DFS = 0x0001,
        SHI1005_FLAGS_DFS_ROOT = 0x0002,
        // these 3 ones are not strict flags, you'll need to use a mask as specified in the official documentation
        CSC_CACHE_AUTO_REINT = 0x0010,
        CSC_CACHE_VDO = 0x0020,
        CSC_CACHE_NONE = 0x0030,
        SHI1005_FLAGS_RESTRICT_EXCLUSIVE_OPENS = 0x00100,
        SHI1005_FLAGS_FORCE_SHARED_DELETE = 0x00200,
        SHI1005_FLAGS_ALLOW_NAMESPACE_CACHING = 0x00400,
        SHI1005_FLAGS_ACCESS_BASED_DIRECTORY_ENUM = 0x00800,
        SHI1005_FLAGS_FORCE_LEVELII_OPLOCK = 0x01000,
        SHI1005_FLAGS_ENABLE_HASH = 0x02000,
        SHI1005_FLAGS_ENABLE_CA = 0x04000,
        SHI1005_FLAGS_ENCRYPT_DATA = 0x08000,
        SHI1005_FLAGS_RESERVED = 0x10000,
    }
