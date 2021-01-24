        private static string GetServicePath(IntPtr service)
        {
            QueryServiceConfig(service, IntPtr.Zero, 0, out int size);
            if (size == 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());
            var ptr = Marshal.AllocHGlobal(size);
            try
            {
                if (!QueryServiceConfig(service, ptr, size, out size))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                var config = Marshal.PtrToStructure<QUERY_SERVICE_CONFIG>(ptr);
                return config.lpBinaryPathName;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        // note that I use a struct, not a class, so I can call Marshal.PtrToStructure.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct QUERY_SERVICE_CONFIG
        {
            public int dwServiceType;
            public int dwStartType;
            public int dwErrorControl;
            public string lpBinaryPathName;
            public string lpLoadOrderGroup;
            public int dwTagID;
            public string lpDependencies;
            public string lpServiceStartName;
            public string lpDisplayName;
        };
        // return is a bool, not need for an int here
        // user SetLastError when the doc says so
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool QueryServiceConfig(IntPtr hService, IntPtr lpServiceConfig, int cbBufSize, out int pcbBytesNeeded);
