        private static async void FillParentIds(IReadOnlyCollection<PortInfo> ports)
		{
			var propertiesToQuery = new List<string> {
				"System.Devices.DeviceInstanceId",
				"System.Devices.Parent"
			};
			var aqs = string.Join(" OR ", ports.Select(p => $"System.Devices.DeviceInstanceId:={p.PnPDeviceId}"));
			var pnpDevices = await PnpObject.FindAllAsync(PnpObjectType.Device, propertiesToQuery, aqs);
			foreach (var pnpDevice in pnpDevices)
			{
				var port = ports.FirstOrDefault(p => string.Compare(p.PnPDeviceId, pnpDevice.Id, StringComparison.InvariantCultureIgnoreCase) == 0);
				if (port != null && pnpDevice.Properties.TryGetValue("System.Devices.Parent", out var parentId))
				{
					port.ParentDeviceId = parentId?.ToString();
				}
			}
		}
