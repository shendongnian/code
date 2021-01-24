    public Startup(IHostingEnvironment env)
    {
        using (var client = new TargetsContext())
        {
            client.Database.EnsureCreated();
        }
    }
