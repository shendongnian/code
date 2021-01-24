    namespace YourApp
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                
                var host = BuildWebHost(args);
    
                using (var scope = host.Services.CreateScope())
                {
                    var env = scope.ServiceProvider.GetRequiredService<IHostingEnvironment>();
    
                    if(env.IsDevelopment())
                    {
                        var services = scope.ServiceProvider;
                        // You can get the Configuration directly withou DI
                        // var config = new ConfigurationBuilder().AddUserSecrets<Startup>().Build();
                        var config = services.GetRequiredService<IConfiguration>();
    
                        string testUserPw = config["SeedUserPW"];
                        if (String.IsNullOrEmpty(testUserPw))
                        {
                            throw new Exception("Use secrets manager to set SeedUserPW \n" +
                                            "dotnet user-secrets set SeedUserPW <pw>");
                       
                        }
    
                        try
                        {
                            SeedData.Initialize(services, testUserPw).Wait();
                        }
                        catch
                        {
                            throw new Exception("You need to update the DB "
                            + "\nPM > Update-Database " + "\n or \n" +
                              "> dotnet ef database update"
                              + "\nIf that doesn't work, comment out SeedData and "
                              + "register a new user");
                        }
                    }
                }
                host.Run();
            }
    
            public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .Build();
        }
    }
