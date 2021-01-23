    foreach (ManagementObject mo in queryCollection)
    {
        double size = Convert.ToDouble(mo["Size"]) / divisor;
        double free = Convert.ToDouble(mo["FreeSpace"]) / divisor;
        double percentFree = (free / size) * 100;
    
        spaceInfo = new Dictionary<string, double>();
        spaceInfo.Add("size",size);
        spaceInfo.Add("freeSpace",free);
        spaceInfo.Add("percentFree",percentFree);
    
        diskInfo.Add(Convert.ToString(mo["Name"]),spaceInfo);
    }
