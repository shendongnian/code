    using System;
    using System.IO;
    using System.ServiceProcess;
    using Cotg.Core2.Contract;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Newtonsoft.Json.Linq;
    
    
    namespace Company.Test.Service
    {
        public class WindowsService : ServiceBase
        {
            public static AppSettings AppSettings;
            public static ICoreLogger Logger;
            private IWebHost _webHost;
    
    
            protected override void OnStart(string[] Args)
            {
                // Parse configuration file.
                string contentRoot = AppDomain.CurrentDomain.BaseDirectory;
                const string environmentalVariableName = "ASPNETCORE_ENVIRONMENT";
                string environment = Environment.GetEnvironmentVariable(environmentalVariableName) ?? EnvironmentNames.Development;
                string configurationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings.json");
                if (File.Exists(configurationFile))
                {
                    JObject configuration = JObject.Parse(File.ReadAllText(configurationFile));
                    AppSettings = configuration.GetValue(environment).ToObject<AppSettings>();
                }
                // Create logger.
                Logger = new ConcurrentDatabaseLogger(Environment.MachineName, AppSettings.AppName, AppSettings.ProcessName, AppSettings.AppLogsDatabase);
                // Create Http.sys web host.
                Logger.Log("Creating web host using HTTP.sys.");
                _webHost = WebHost.CreateDefaultBuilder(Args)
                    .UseStartup<WebApiStartup>()
                    .UseContentRoot(contentRoot)
                    .UseHttpSys(Options =>
                    {
                        Options.Authentication.Schemes = AppSettings.AuthenticationSchema;
                        Options.Authentication.AllowAnonymous = AppSettings.AllowAnonymous;
                        Options.MaxConnections = AppSettings.MaxConnections;
                        Options.MaxRequestBodySize = AppSettings.MaxRequestBodySize;
                        // Allow external access to service by opening TCP port via an Inbound Rule in Windows Firewall.
                        // To run service using a non-administrator account, grant the user access to URL via netsh.
                        //   Use an exact URL: netsh http add urlacl url=http://servername:9092/ user=domain\user.
                        //   Do not use a wildcard URL: netsh http add urlacl url=http://+:9092/ user=domain\user.
                        Options.UrlPrefixes.Add(AppSettings.Url);
                    })
                    .Build();
                _webHost.Start();
                Logger.Log($"Web host started.  Listening on {AppSettings.Url}.");
            }
    
    
            protected override void OnStop()
            {
                _webHost?.StopAsync(TimeSpan.FromSeconds(60));
            }
        }
    }
