    public ulong GetAvailableRamInBytes()
    {
        ComputerInfo c = new ComputerInfo();
        ulong u = ulong.Parse(c.AvailablePhysicalMemory.ToString());
        return u;
    }
    // (GetAvailableRamInBytes() / 1048576) + "mb"
