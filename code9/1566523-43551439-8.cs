    _server = new TestServer(new WebHostBuilder()
        .ConfigureServices(services =>
        {
            services.AddScoped<IFooService, MockService>();
        })
        .UseStartup<Startup>()
    );
    
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //use TryAdd to support mocking the service
            services.TryAddTransient<IFooService, FooService>();
        }
    }
