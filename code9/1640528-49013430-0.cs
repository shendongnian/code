    public class Program
    {
       public static void Main(string[] args)
       {
          BuildWebHost(args).Run();
       }
    
       public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration(ConfigConfiguration)
                 .UseStartup<Startup>()
                 .Build();
    
       static void ConfigConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder config)
       {
                config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"config.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
    
       }
     }
