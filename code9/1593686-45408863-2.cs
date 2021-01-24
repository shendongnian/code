    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile(@"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        // This adds EB environment variables.
        builder.AddInMemoryCollection(GetAwsDbConfig(builder.Build()));
        Configuration = builder.Build();
    }
    private Dictionary<string, string> GetAwsDbConfig(IConfiguration configuration)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (IConfigurationSection pair in configuration.GetSection("iis:env").GetChildren())
            {
                string[] keypair = pair.Value.Split(new[] { '=' }, 2);
                dict.Add(keypair[0], keypair[1]);
            }
            return dict;
        }
    private string GetRdsConnectionString()
    {
        string hostname = Configuration.GetValue<string>("RDS_HOSTNAME");
        string port = Configuration.GetValue<string>("RDS_PORT");
        string dbname = Configuration.GetValue<string>("RDS_DB_NAME");
        string username = Configuration.GetValue<string>("RDS_USERNAME");
        string password = Configuration.GetValue<string>("RDS_PASSWORD");
        return $"Data Source={hostname},{port};Initial Catalog={dbname};User ID={username};Password={password};";
    }
