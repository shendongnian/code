        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile(@"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            builder.AddInMemoryCollection(ParseEbConfig(config));
            Configuration = builder.Build();
        }
        private static Dictionary<string, string> ParseEbConfig(IConfiguration config)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (IConfigurationSection pair in config.GetSection("iis:env").GetChildren())
            {
                string[] keypair = pair.Value.Split(new[] { '=' }, 2);
                dict.Add(keypair[0], keypair[1]);
            }
            return dict;
        }
