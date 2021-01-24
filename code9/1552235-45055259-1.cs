    using System.IO;
    using Microsoft.AspNetCore.Hosting;
     
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var host = new Microsoft.AspNetCore.Hosting.WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
     
                host.Run();
            }
        }
    }
