    public static bool IsWindowsActivated()
    {
        ManagementScope scope = new ManagementScope(@"\\" + System.Environment.MachineName + @"\root\cimv2");
        scope.Connect();
        SelectQuery searchQuery = new SelectQuery("SELECT * FROM SoftwareLicensingProduct WHERE ApplicationID = '55c92734-d682-4d71-983e-d6ec3f16059f' and LicenseStatus = 1");
        ManagementObjectSearcher searcherObj = new ManagementObjectSearcher(scope, searchQuery);
        using (ManagementObjectCollection obj = searcherObj.Get())
        {
            return obj.Count > 0;
        }
    }
