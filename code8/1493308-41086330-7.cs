    ...
    using System.Management;     // Project > Add Reference required
        public static void QueryWorkingset() {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT Name, WorkingSetPrivate FROM Win32_PerfRawData_PerfProc_Process");
            foreach (ManagementObject queryObj in searcher.Get()) {
                Console.WriteLine("{0}: {1}", queryObj["Name"], queryObj["WorkingSetPrivate"]);
            }
        }
