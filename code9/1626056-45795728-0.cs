using SW = System.Windows;
    private TestClass()
	{
		if (SW.Application.Current == null)
		{
			new SW.Application
			{
				ShutdownMode = SW.ShutdownMode.OnExplicitShutdown
			};
		}
	}
