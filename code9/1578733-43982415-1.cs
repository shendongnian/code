    var usersSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");
    var managementObjects = usersSearcher.Get();
    List<string> result = new List<string>();
    foreach (ManagementObject item in managementObjects)
    {
        foreach (var pr in item.Properties)
        {
            if (pr.Name == "Caption")
            {
                result.Add(pr.Value?.ToString());
            }
        }
    }
    var users = result.Distinct().ToList();
