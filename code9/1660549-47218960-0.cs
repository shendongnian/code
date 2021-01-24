    public class Program
    {
        public static int Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.RollingFile(configuration.GetValue<string>("LogFilePath") + "-{Date}.txt", LogEventLevel.Information)
				.CreateLogger();
	
            try
            {
                Log.Information("Starting web host");
                BuildWebHost(args).Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Web Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((ctx, builder) =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddSerilog();
            })
            .UseStartup<Startup>()
            .Build();
    }
