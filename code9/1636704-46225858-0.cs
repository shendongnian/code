    System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
    
    ServiceBase[] ServicesToRun;
    
    ServicesToRun = new ServiceBase[]
    {
    	new MyService()
    };
    
    ServiceBase.Run(ServicesToRun);
