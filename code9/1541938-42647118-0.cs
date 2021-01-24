    lstTrace.Items.AddRange(
        NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(nic => nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            .Select(nice=>nic.Name)
    );
