    public class Program
    {
        public static void Main(string[] args)
        {
            var contentRoot = Directory.GetCurrentDirectory();
     
            var config = new ConfigurationBuilder()
               .SetBasePath(contentRoot)
               .AddJsonFile("hosting.json", optional: true)
               .Build();
     
            //WebHostBuilder is required to build the server. We are configurion all of the properties on it
            var hostBuilder = new WebHostBuilder()
    		
                .UseKestrel()
    			
                 //Content root - in this example it will be our current directory
                .UseContentRoot(contentRoot)
     
                //Web root - by the default it's wwwroot but here is the place where you can change it
                //.UseWebRoot("wwwroot")
     
                //Startup
                .UseStartup<Startup>()
     
                .UseConfiguration(config);
     
            var host = hostBuilder.Build();
            //Let's start listening for requests
            host.Run();
        }
    }
