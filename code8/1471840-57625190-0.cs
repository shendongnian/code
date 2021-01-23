        private static List<PortInfo> GetActivePorts()
		{
			var ports = new List<PortInfo>();
			using (var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SerialPort"))
			using (var collection = searcher.Get())
			{
				foreach (var device in collection)
				{
					var portInfo = new PortInfo
					{
						Port = (string)device.GetPropertyValue("DeviceID"),
						PnPDeviceId = (string)device.GetPropertyValue("PNPDeviceID")
					};
					if (!string.IsNullOrEmpty(portInfo.Port) && !string.IsNullOrEmpty(portInfo.PnPDeviceId))
					{
						ports.Add(portInfo);
					}
				}
			}
			return ports;
		}
