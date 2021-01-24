    using Microsoft.Extensions.DependencyInjection;
    using System;
    namespace Serilog.Injection
    {
        public static class RegisterSerilogServices
        {
            public static IServiceCollection AddSerilogServices(this IServiceCollection services)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.MSSqlServer(@"xxxxxxxxxxxxx", "Logs")
                    .CreateLogger();
    
                AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
    
                return services.AddSingleton(Log.Logger);
            }
        }
    }
