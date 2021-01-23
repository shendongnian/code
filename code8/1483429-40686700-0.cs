    public Startup(IHostingEnvironment env) {
        ...
        if (env.IsDevelopment()) {
            // BELOW IS THE IMPORTANT LINE
            builder.AddUserSecrets();
        }
        ...
        // This is important, too. It sets up a readonly property
        // that you can use to access your user secrets.
        Configuration = builder.Build();
    }
    // This is the read-only property
    public IConfigurationRoot Configuration { get; }
