	class Program
    {
		static void Main(string[] args)
		{
		
			if (args.Length == 1 && args[0] == "/debug")
			{
				// Run as a Console Application
				new MyService().DoTheServiceLogic();
			}
			else
			{
				// Run as a Windows Service
				ServiceBase[] ServicesToRun = new ServiceBase[] 
				{ 
					new MyService() 
				};
				
				ServiceBase.Run(ServicesToRun);
			}
		}
	}
