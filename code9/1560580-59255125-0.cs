	//InitializeComponent();
	using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(
		"SOFTWARE\\VideoLAN\\VLC",
		 RegistryKeyPermissionCheck.ReadSubTree,
		RegistryRights.QueryValues))
	{
		_Vlc.SourceProvider.CreatePlayer(
		new DirectoryInfo(rk.GetValue("InstallDir") as string),
		new string[] { });
	}
