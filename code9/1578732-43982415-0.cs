    var usersSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Process");
    var managementObjects = usersSearcher.Get();
    List<string> allUsers = new List<string>();
    
    foreach (ManagementObject obj in managementObjects)
    {
        string[] argList = new string[] { string.Empty, string.Empty };
        int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
        if (returnVal == 0)
        {
            // return DOMAIN\user
            allUsers.Add(argList[1] + "\\" + argList[0]);
        }
    }
    
    var result = allUsers.Distinct().ToList();
