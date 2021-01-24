    public override void Configure(INancyEnvironment environment)
    {
        base.Configure(environment);
    #if DEBUG
        // Disable view caching in debug mode
        environment.Views(true, true);
    #endif
    }
