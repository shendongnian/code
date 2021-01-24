     var nics = from NetworkInterface a
                      in NetworkInterface.GetAllNetworkInterfaces()
                       where a.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                       a.Supports(NetworkInterfaceComponent.IPv4)
                       select a;
        if (nics.Any())
        {
            var nic = nics.First();
            adapter = new NetworkAdapter();
            adapter.Name = nic.Name;
            adapter.Description = nic.Description;
            adapter.Id = nic.Id;
            var props = nic.GetIPProperties();
            var ipAddresses = from UnicastIPAddressInformation info
                              in props.UnicastAddresses
                              where info.PrefixOrigin == PrefixOrigin.Manual
                              select info;
            adapter.GatewayAddressList = nic.GetIPProperties().GatewayAddresses;
            adapter.Available = (nic.OperationalStatus == OperationalStatus.Up);
        }
