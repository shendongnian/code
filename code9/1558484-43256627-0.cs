	static int Main(string[] args)
	{
		UnityContainer container = new UnityContainer();
		UnityRegistrer.Register(container);	// Your proper registrations
		
		bool isIntegratedTest = Super.Logic(); // Get from config, argument, whatever.
		
		if (isIntegratedTest)
			UnityRegistrerTest.Register(container);
			
		RestOfTheProgram();
	}
		
	public static class UnityRegistrer
	{
		public static void Register(IUnityContainer container)
		{
			container.RegisterType<ICommunicationGate, CommunicationGate>("ImplementationOne");
			container.RegisterType<ICommunicationGate, CommunicationGate>("ImplementationTwo",
				new InjectionConstructor(new InjectionParameter<Whatever>("Blah")));
		}
	}
	public static class UnityRegistrerTest
	{
		public static void Register(IUnityContainer container)
		{
			container.RegisterType<ICommunicationGate, CommunicationGateMock>("ImplementationOne");
		}
	}
