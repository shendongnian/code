    public bool IsMadeByApple()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
        ManagementObjectCollection collection = searcher.Get();
        string manufacturer = "";
        foreach (ManagementObject obj in collection)
        {
            manufacturer = (string)obj["Manufacturer"]; // Will be "Apple Inc." if it's an Apple computer
        }
        return (manufacturer == "Apple Inc.");
    }
