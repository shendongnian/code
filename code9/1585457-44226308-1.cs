	void Main()
	{
		Console.WriteLine(GetMacByIP("10.10.10.100"));
	}
	
	public string GetMacByIP(string ipAddress)
	{
		var query = NetworkInterface.GetAllNetworkInterfaces()
			.Where(n =>
				n.OperationalStatus == OperationalStatus.Up && // only grabbing what's online
				n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
			.Select(_ => new
			{
				PhysicalAddress = _.GetPhysicalAddress(),
				IPProperties = _.GetIPProperties(),
			});
			
		return query
            .Where(q => q.IPProperties.UnicastAddresses
                .Any(ua => ua.Address.ToString() == ipAddress))
            .FirstOrDefault()
            .PhysicalAddress.ToString();
	}
