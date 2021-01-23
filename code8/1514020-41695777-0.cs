    static List<USBDeviceInfo> GetUSBDevices()
    {
        ManagementObjectCollection collection;
        using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            collection = searcher.Get();
        foreach (var device in collection)
        {
            if(device.GetPropertyValue("Description").Equals("PI C-863"))
            {
                 Console.WriteLine("Found PI C-863!");
                 break;
            }
            
        }
        collection.Dispose();
        return devices;
    }
