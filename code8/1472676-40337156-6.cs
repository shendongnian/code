    using System.IO;  // for Directory
    using Microsoft.AspNetCore.Hosting;  // for WebHostBuilder()
    
    namespace ApiCall
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>()
                    .Build();
    
                host.Run();
            }
        }
    }
