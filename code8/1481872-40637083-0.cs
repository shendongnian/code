	public static void InstallService(string serviceName, Assembly assembly)
	{
		if (IsServiceInstalled(serviceName))
		{
			return;
		}
		using (AssemblyInstaller installer = GetInstaller(assembly))
		{
			IDictionary state = new Hashtable();
			try
			{
				installer.Install(state);
				installer.Commit(state);
			}
			catch
			{
				try
				{
					installer.Rollback(state);
				}
				catch { }
				throw;
			}
		}
	}
	
	public static bool IsServiceInstalled(string serviceName)
	{
		using (ServiceController controller = new ServiceController(serviceName))
		{
			try
			{
				ServiceControllerStatus status = controller.Status;
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
	
	private static AssemblyInstaller GetInstaller(Assembly assembly)
	{
		AssemblyInstaller installer = new AssemblyInstaller(assembly, null);
		installer.UseNewContext = true;
		return installer;
	}
