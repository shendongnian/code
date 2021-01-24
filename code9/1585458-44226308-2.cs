	void Main()
	{
		Console.WriteLine(GetMacByIP("192.168.15.161")); // will return "00-E2-4C-98-18-89"
	}
	
	public string GetMacByIP(string ipAddress)
	{
		// grab all online interfaces
		var query = NetworkInterface.GetAllNetworkInterfaces()
			.Where(n =>
				n.OperationalStatus == OperationalStatus.Up && // only grabbing what's online
				n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
			.Select(_ => new
			{
				PhysicalAddress = _.GetPhysicalAddress(),
				IPProperties = _.GetIPProperties(),
			});
			
		// grab the first interface that has a unicast address that matches your search string
		var mac = query
			.Where(q => q.IPProperties.UnicastAddresses
				.Any(ua => ua.Address.ToString() == ipAddress))
			.FirstOrDefault()
			.PhysicalAddress;
			
		// return the mac address with formatting (eg "00-00-00-00-00-00")
		return String.Join("-", mac.GetAddressBytes().Select(b => b.ToString("X2")));
	}
