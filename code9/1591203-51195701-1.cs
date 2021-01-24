    public static void Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var hostingEnvironment = services.GetService<IHostingEnvironment>();
            
            if (!hostingEnvironment.IsProduction())
               SeedData.Initialize();
        }
        host.Run();
    }
