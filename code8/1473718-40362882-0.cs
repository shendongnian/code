    var macAddr = 
        NetworkInterface.GetAllNetworkInterfaces()
        .Where(nic => nic.OperationalStatus == OperationalStatus.Up)
        .Select(nic => nic.GetPhysicalAddress().ToString())
        .FirstOrDefault();
