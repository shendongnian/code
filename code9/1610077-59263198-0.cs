 public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<YourDbContext>();
            context.Database.EnsureCreated();
            if (!context.Items.Any())
            {
                context.Items.Add(entity: new Item() { Name = "Green Thunder" });
                context.Items.Add(entity: new Item() { Name = "Berry Pomegranate" });
                context.Items.Add(entity: new Item() { Name = "Betty Crocker" });
                context.Items.Add(entity: new Item() { Name = "Pizza Crust Mix" });
                context.SaveChanges();
            }
            if (!context.Shoppings.Any()) {
                context.Shoppings.Add(entity:new Shopping() { Name="Defualt" });
            }
        }
    }
update your program.cs code for inserting your seed data like below
 public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<YourDbContext>();
                    context.Database.Migrate(); // apply all migrations
                    SeedData.Initialize(services); // Insert default data
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
