    lstTrace.Items.AddRange(
        NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(nic => nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            .Select(nic => nic.Name)
            .ToArray()
    );
