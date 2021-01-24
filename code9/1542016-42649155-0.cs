    static void Main(string[] args)
    {
    #if DEBUG // If you are currently in debug mode
        ClientService service = new ClientService (); // create your service's instance
        service.Start(args); // start this service
        Console.ReadLine(); // wait for user input ( enter key )
    #else // else you're in release mode
        ServiceBase[] ServicesToRun; // start service normally
        ServicesToRun = new ServiceBase[] 
        { 
            new MyService() 
        };
        ServiceBase.Run(ServicesToRun);
    #endif
    }
