	static void Main(string[] args)
	{
        // Begin Composition Root
		var container = new SimpleInjector.Container();
		// Registrations here.
		container.Register<ILogger, FileLogger>();
		container.Register<IMainAgent, MainAgent>();
		//Verify the container.
		container.Verify();
        // End Composition Root
		MainAgent agent = container.GetInstance<IMainAgent>();
		//Start Main Agent
		agent.Start();
	}
