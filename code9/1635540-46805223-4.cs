    public static void Main(string[] args)
    {
        XmlDocument log4netConfig = new XmlDocument();
        log4netConfig.Load(File.OpenRead("log4net.config"));
        var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                   typeof(log4net.Repository.Hierarchy.Hierarchy));
        log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        BuildWebHost(args).Run();
    }
