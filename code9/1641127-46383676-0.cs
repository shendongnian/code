    public void Configure(IApplicationBuilder app)
    {
        GetMeSomeServiceLocator.Instance = app.ApplicationServices;
    }
    
    public static class GetMeSomeServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
