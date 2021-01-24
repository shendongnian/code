    //using System.Management;
    private static string getWorkstationDomain(string workstationName)
    {
        ManagementObjectSearcher searcher =
            new ManagementObjectSearcher(@"\\workstationName\root\CIMV2",
            "SELECT * FROM Win32_ComputerSystem");
        var results = searcher.Get();
        var domain = results
            .OfType<ManagementObject>()
            .Select(mo => (string)mo.Properties["Domain"].Value)
            .FirstOrDefault();
        return domain;
    }
