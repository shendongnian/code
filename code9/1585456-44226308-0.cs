	void Main()
	{
		var foo = GetNetworkInterfaceData().FirstOrDefault(); // only grabbing one
        
        // grabbing the first unicast address, you'll need to solve this differently
		string ipAddress = foo.IPProperties.UnicastAddresses[0].Address.ToString();
 		string macAddress = foo.PhysicalAddress.ToString();
	}
	public class NetworkInterfaceData
	{
		public PhysicalAddress PhysicalAddress { get; set; }
		public IPInterfaceProperties IPProperties { get; set; } 
	}
	public static IEnumerable<NetworkInterfaceData> GetNetworkInterfaceData()
	{
		return NetworkInterface.GetAllNetworkInterfaces()
			.Where(n =>
				n.OperationalStatus == OperationalStatus.Up && // only grabbing what's online
				n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
			.OrderByDescending(n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
			.Select(_ => new NetworkInterfaceData
            {
				PhysicalAddress = _.GetPhysicalAddress(),
				IPProperties = _.  GetIPProperties(),
			});
	}
