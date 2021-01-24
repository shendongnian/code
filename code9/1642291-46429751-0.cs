    public StartUp(IHostingEnvironment env)
    {
        ...
        HostingEnvironment = env;
    }
    public IHostingEnvironment HostingEnvironment { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        // you can now use `HostingEnvironment` here, without injecting it.
    }
