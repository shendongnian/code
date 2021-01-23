    public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseConfiguration(Configuration)
                    .ConfigureLogging(log => { log.AddSerilog(Log.Logger); })
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
