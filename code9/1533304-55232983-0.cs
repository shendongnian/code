    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PersonContext>();
                context.Database.Migrate();
            }
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
