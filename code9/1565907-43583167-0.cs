    IPNetwork addressSpaceRange = IPNetwork.Parse("172.20.0.0/24");
    IPNetwork subnetAddressRange = IPNetwork.Parse("172.20.0.0/25");
    Console.WriteLine($"Address space [{addressSpaceRange.ToString()}]:");
    Console.WriteLine($"FirstUsable address:{addressSpaceRange.FirstUsable}");
    Console.WriteLine($"LastUsable address:{addressSpaceRange.LastUsable}\r\n");
    Console.WriteLine($"Subnet address range [{subnetAddressRange.ToString()}]:");
    Console.WriteLine($"FirstUsable address:{subnetAddressRange.FirstUsable}");
    Console.WriteLine($"LastUsable address:{subnetAddressRange.LastUsable}\r\n");
    Console.WriteLine("addressSpaceRange contains subnetAddressRange:" + IPNetwork.Contains(addressSpaceRange, subnetAddressRange));
