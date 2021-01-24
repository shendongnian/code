    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = configBuilder.Build();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(context => config).As<IConfiguration>();
            containerBuilder.RegisterType<BusSettings>();
            var container = containerBuilder.Build();
            var busSettings = container.Resolve<BusSettings>();
            
            Console.WriteLine(busSettings.HostAddress.ToString());
            Console.Read();
        }
    }
