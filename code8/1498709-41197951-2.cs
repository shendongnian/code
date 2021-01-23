    public static void Main(string[] args)
    {
        ...
        Startup.Container.RegisterSingleton<MyService>();
        Startup.Container.RegisterSingleton<IWebHost>(host);
        Startup.Container.Verify();
        ...
    }
