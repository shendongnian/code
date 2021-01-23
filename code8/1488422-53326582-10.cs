                IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();
                ConnectionStringWrapper settings = new ConnectionStringWrapper();
                config.Bind("ConnectionStringWrapperSettings", settings);
                Console.WriteLine("{0}, {1}", settings.DefaultConnectionStringName, settings.ConnectionStringEntries.Count);
                ConnectionStringEntry cse = settings.GetDefaultConnectionStringEntry();
