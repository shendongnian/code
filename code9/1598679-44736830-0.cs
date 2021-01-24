    using System.IO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    
    namespace MyApi
    {
            public class Program
        {
            public static void Main(string[] args)
            {
                //UseUrls does the trick.
                var host = new WebHostBuilder()
                    .UseUrls("http://*:53325")
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
    
                host.Run();
            }
        }
    }
