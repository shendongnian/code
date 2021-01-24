        public class Program
        {
        public static void Main(string[] args)
        {
        // The ConfigureServices call here allows for
        // ConfigureContainer to be supported in Startup with
        // a strongly-typed ContainerBuilder.
        var host = new WebHostBuilder()
            .UseKestrel()
            .ConfigureServices(services => services.AddAutofac())
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
    
        host.Run();
        }
        }
