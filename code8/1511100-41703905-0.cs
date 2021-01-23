    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
            
        CoreCurrent.Protector = ActivatorUtilities.CreateInstance<DataProtect>(host.Services);
        Current.Services = host.Services;
        Current.SetDbConfigurationState();
        host.Run(Current.AppCancellationSource.Token);
        
        //reset token and call main again
        host.Dispose();
        Current.AppCancellationSource = new System.Threading.CancellationTokenSource();
        Main(args);
    }
