    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder();
            
             // register your configuration and services.
            ....
            await hostBuilder.RunConsoleAsync();
        }
    }
