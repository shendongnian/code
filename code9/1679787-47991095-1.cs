    public ulong GetAvailableRamInBytes()
    {
        return ulong.Parse(new ComputerInfo().AvailablePhysicalMemory.ToString());
    }
    // (GetAvailableRamInBytes() / 1048576) + "mb"
