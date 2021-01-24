	public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<UpdateServerContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred while seeding the database.");
                }
            }
            try
            {
                Log.Information("Starting web host");
                host.Run();
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Starting web host failed.");
            }
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>()
                .Build();
    }
