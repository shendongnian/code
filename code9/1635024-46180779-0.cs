    public class Program
    {
        public static IWebHost BuildWebHost(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.SetBasePath(env.ContentRootPath);
                    config.AddInMemoryCollection(new[]
                           {
                             new KeyValuePair<string,string>("the-key", "the-value")
                           })
                           .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                           .AddJsonFile($"appsettings.{env}.json", optional: true)
                           .AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddDebug();
                    logging.AddConsole();
                })
                .UseIISIntegration()
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .UseStartup<Startup>()
                .Build();
            return host;
        }
        
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
    }
