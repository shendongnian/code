    using System;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Hosting.Internal;
    namespace MyApplication.Common
    {
        public static class ConfigurationFactory
        {
            /// <summary>
            /// Use for ASP.NET Core Web applications.
            /// </summary>
            /// <param name="config"></param>
            /// <param name="env"></param>
            /// <returns></returns>
            public static IConfigurationBuilder Configure(IConfigurationBuilder config, IHostingEnvironment env)
            {
                return Configure(config, env.EnvironmentName);
            }
            /// <summary>
            /// Use for .NET Core Console applications.
            /// </summary>
            /// <param name="config"></param>
            /// <param name="env"></param>
            /// <returns></returns>
            private static IConfigurationBuilder Configure(IConfigurationBuilder config, Microsoft.Extensions.Hosting.IHostingEnvironment env)
            {
                return Configure(config, env.EnvironmentName);
            }
            private static IConfigurationBuilder Configure(IConfigurationBuilder config, string environmentName)
            {
                return config
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            }
            /// <summary>
            /// Use for .NET Core Console applications.
            /// </summary>
            /// <returns></returns>
            public static IConfiguration CreateConfiguration()
            {
                var env = new HostingEnvironment
                {
                    EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                    ApplicationName = AppDomain.CurrentDomain.FriendlyName,
                    ContentRootPath = AppDomain.CurrentDomain.BaseDirectory,
                    ContentRootFileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory)
                };
                var config = new ConfigurationBuilder();
                var configured = Configure(config, env);
                return configured.Build();
            }
        }
    }
