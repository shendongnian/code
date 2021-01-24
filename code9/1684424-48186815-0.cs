    private IWebHost _webHost;
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Create the host
        _webHost = WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
        //We want to start, not run because we need the rest of the app to run
        _webHost.Start();
        //Run the app as normal
        Application.Run(new MainForm());
        //We're back from the app now, we can stop the host
        //...
    }
