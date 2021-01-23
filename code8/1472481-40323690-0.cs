	PleaseWaitPopup.IsOpen = true;
	Task.Run(() =>
	{
		try
		{
			wifiDeviceProvider = new PtpIpProvider();
			DeviceManager.AddDevice(wifiDeviceProvider.Connect("192.168.1.1"));
		}
		catch (Exception ex)
		{
			...
		}
	});
