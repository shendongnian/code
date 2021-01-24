    // Find app directory.
    var isService = !(Debugger.IsAttached || args.Contains("--console"));
    var currentDir = Directory.GetCurrentDirectory();
    if (isService)
    {
        var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
        currentDir = Path.GetDirectoryName(pathToExe);
    }
    // Configure web host
    var host = WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(currentDir)
            .UseWebRoot(Path.Combine(currentDir, "wwwroot"));
            .UseStartup<Startup>()
            .Build();
    // Run.
    if (isService)
    {
        host.RunAsService();
    }
    else
    {
        host.Run();
    }
