    public enum Share_Type : uint
        {
            STYPE_DISKTREE = 0x00000000,   // Disk Drive
            STYPE_PRINTQ = 0x00000001,   // Print Queue
            STYPE_DEVICE = 0x00000002,   // Communications Device
            STYPE_IPC = 0x00000003,   // InterProcess Communications
            STYPE_SPECIAL = 0x80000000,   // Special share types (C$, ADMIN$, IPC$, etc)
            STYPE_TEMPORARY = 0x40000000   // Temporary share 
        }
        public enum Share_ReturnValue : int
        {
            NERR_Success = 0,
            ERROR_ACCESS_DENIED = 5,
            ERROR_NOT_ENOUGH_MEMORY = 8,
            ERROR_INVALID_PARAMETER = 87,
            ERROR_INVALID_LEVEL = 124, // unimplemented level for info
            ERROR_MORE_DATA = 234,
            NERR_BufTooSmall = 2123, // The API return buffer is too small.
            NERR_NetNameNotFound = 2310 // This shared resource does not exist.
        }
        [System.Flags]
        public enum Shi1005_flags
        {
            SHI1005_FLAGS_DFS = 0x0001,  // Part of a DFS tree (Cannot be set)
            SHI1005_FLAGS_DFS_ROOT = 0x0002,  // Root of a DFS tree (Cannot be set)
            SHI1005_FLAGS_RESTRICT_EXCLUSIVE_OPENS = 0x0100,  // Disallow Exclusive file open
            SHI1005_FLAGS_FORCE_SHARED_DELETE = 0x0200,  // Open files can be force deleted
            SHI1005_FLAGS_ALLOW_NAMESPACE_CACHING = 0x0400,  // Clients can cache the namespace
            SHI1005_FLAGS_ACCESS_BASED_DIRECTORY_ENUM = 0x0800,  // Only directories for which a user has FILE_LIST_DIRECTORY will be listed
            SHI1005_FLAGS_FORCE_LEVELII_OPLOCK = 0x1000,  // Prevents exclusive caching
            SHI1005_FLAGS_ENABLE_HASH = 0x2000,  // Used for server side support for peer caching
            SHI1005_FLAGS_ENABLE_CA = 0X4000   // Used for Clustered shares
        }
        public static class NetApi32
        {
            // ********** Structures **********
            // SHARE_INFO_502
            [StructLayout(LayoutKind.Sequential)]
            public struct SHARE_INFO_502
            {
                [MarshalAs(UnmanagedType.LPWStr)]
                public string shi502_netname;
                public uint shi502_type;
                [MarshalAs(UnmanagedType.LPWStr)]
                public string shi502_remark;
                public Int32 shi502_permissions;
                public Int32 shi502_max_uses;
                public Int32 shi502_current_uses;
                [MarshalAs(UnmanagedType.LPWStr)]
                public string shi502_path;
                public IntPtr shi502_passwd;
                public Int32 shi502_reserved;
                public IntPtr shi502_security_descriptor;
            }
            // SHARE_INFO_1005
            [StructLayout(LayoutKind.Sequential)]
            public struct SHARE_INFO_1005
            {
                public Int32 Shi1005_flags;
            }
            private class unmanaged
            {
                //NetShareGetInfo
                [DllImport("Netapi32.dll", SetLastError = true)]
                internal static extern int NetShareGetInfo(
                    [MarshalAs(UnmanagedType.LPWStr)] string serverName,
                    [MarshalAs(UnmanagedType.LPWStr)] string netName,
                    Int32 level,
                    ref IntPtr bufPtr
                );
                [DllImport("Netapi32.dll", SetLastError = true)]
                public extern static Int32 NetShareSetInfo(
                    [MarshalAs(UnmanagedType.LPWStr)] string servername,
                    [MarshalAs(UnmanagedType.LPWStr)] string netname, Int32 level, IntPtr bufptr, out Int32 parm_err);
            }
            // ***** Functions *****
            public static SHARE_INFO_502 NetShareGetInfo_502(string ServerName, string ShareName)
            {
                Int32 level = 502;
                IntPtr lShareInfo = IntPtr.Zero;
                SHARE_INFO_502 shi502_Info = new SHARE_INFO_502();
                Int32 result = unmanaged.NetShareGetInfo(ServerName, ShareName, level, ref lShareInfo);
                if ((Share_ReturnValue)result == Share_ReturnValue.NERR_Success)
                {
                    shi502_Info = (SHARE_INFO_502)Marshal.PtrToStructure(lShareInfo, typeof(SHARE_INFO_502));
                }
                else
                {
                    throw new Exception("Unable to get 502 structure.  Function returned: " + (Share_ReturnValue)result);
                }
                return shi502_Info;
            }
            public static SHARE_INFO_1005 NetShareGetInfo_1005(string ServerName, string ShareName)
            {
                Int32 level = 1005;
                IntPtr lShareInfo = IntPtr.Zero;
                SHARE_INFO_1005 shi1005_Info = new SHARE_INFO_1005();
                Int32 result = unmanaged.NetShareGetInfo(ServerName, ShareName, level, ref lShareInfo);
                if ((Share_ReturnValue)result == Share_ReturnValue.NERR_Success)
                {
                    shi1005_Info = (SHARE_INFO_1005)Marshal.PtrToStructure(lShareInfo, typeof(SHARE_INFO_1005));
                }
                else
                {
                    throw new Exception("Unable to get 1005 structure.  Function returned: " + (Share_ReturnValue)result);
                }
                return shi1005_Info;
            }
            public static int NetShareSetInfo_1005(string ServerName, string ShareName, SHARE_INFO_1005 shi1005_Info) //  Int32 Shi1005_flags
            {
                Int32 level = 1005;
                Int32 err;
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(shi1005_Info));
                Marshal.StructureToPtr(shi1005_Info, ptr, false);
                var result = unmanaged.NetShareSetInfo(ServerName, ShareName, level, ptr, out err);
                return result;
            }
        }
        static void Main(string[] args)
        {
            abeTest();
        }        
        public static void abeTest()
        {            
            NetApi32.SHARE_INFO_1005 test = new NetApi32.SHARE_INFO_1005();
            test.Shi1005_flags = 2048;
            NetApi32.NetShareSetInfo_1005("FileStore2", "TestShare2$", test);
        }
