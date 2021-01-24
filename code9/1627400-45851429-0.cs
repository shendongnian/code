        public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
    
            host.Run();
        }
    
        // Tools will use this to get application services
        public static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
  
