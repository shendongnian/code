    class Program {
       // declare a field to store config values
       private readonly IConfigurationRoot _configuration;
       // Declare a constructor 
       public Program()
       {
           var builder = new ConfigurationBuilder()
                .SetBasePath(environment.BasePath)
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
       }
     }
      public static void Main(string[] args)
      {
         var program = new Program();
         var serviceCollection = new ServiceCollection();
         program.ConfigureServices(serviceCollection);
         var serviceProvider = serviceCollection.BuildServiceProvider();
         // now here you can resolve your DbContext similar to web
          services.AddDbContext<MooodDbContext>(options =>
              options.UseSqlServer(_configuration.GetConnectionString("MooodConnection")));
      }
    }
