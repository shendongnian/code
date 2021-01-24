    var nics = NetworkInterface.GetAllNetworkInterfaces();
    foreach (var networkInterface in nics)
    {
        if (networkInterface.OperationalStatus == OperationalStatus.Up)
        {
            var address = networkInterface.GetPhysicalAddress();
        }
    }
