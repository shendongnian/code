        [StructLayout(LayoutKind.Sequential)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer); 
        // Alternate Version Using "ref," And Works With Alternate Code Below.
        // Also See Alternate Version Of [MEMORYSTATUSEX] Defined As A Structure. 
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint = "GlobalMemoryStatusEx", SetLastError = true)]
        static extern bool _GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);
        void GetProcessUsage()
        {
            MEMORYSTATUSEX data = new MEMORYSTATUSEX();
            GlobalMemoryStatusEx(data);
            System.Diagnostics.Debug.WriteLine(data.ullTotalPageFile + "\t\t" + data.ullAvailPageFile);
        }
