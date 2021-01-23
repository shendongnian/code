    var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            var serviceProvider = new ServiceCollection()
                    .AddDbContext<MyDbContext>(optionns => optionns.UseSqlServer(configuration.GetConnectionString("connectionString")))
                    .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
                    .AddLogging() 
                    .BuildServiceProvider();
            MyDbContext _context = serviceProvider.GetService<MyDbContext>();
            var _logger = serviceProvider.GetService<ILogger<YourClass>>();
