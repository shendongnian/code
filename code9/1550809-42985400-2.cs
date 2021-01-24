    public class Authentication
    {
        public FacebookOptions Google { get; set; }
        public GoogleOptions Google { get; set; }
    }
    // load configuration
    public Startup(IHostingEnvironment env)
    {
        // Set up configuration sources.
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
        Configuration = builder.Build();
        var options = new Authentication();
        config.GetSection("Authentication").Bind(options);
    }
