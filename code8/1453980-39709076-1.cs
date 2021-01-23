	public static async Task TestSimulator()
	{
		var proxyFile = await Package.Current.InstalledLocation.GetFileAsync(@"WindowsStoreProxy.xml");
		await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
	}
