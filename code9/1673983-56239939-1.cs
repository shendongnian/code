    public void ConnectToRemoteDesktop((string username, string domain, string password, string machineName) credentials)
		{
			RemoteDesktopApi.MessageLoopApartment.I.Run(() =>
			{
				var ca = new RemoteDesktopApi();
				ca.Connect(credentials);
			}, CancellationToken.None);
		}
