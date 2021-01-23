    private int coreCountNum()
    {
        using(var searcher = new System.Management.ManagementObjectSearcher("Select NumberOfCores from Win32_Processor"))
        {
            int coreCount = 0;
            foreach (var item in searcher.Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());    
            }
            return coreCount;
        }
    }
