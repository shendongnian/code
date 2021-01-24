    public static void Register(HttpConfiguration config)
    {
        config.AddApiVersioning(versioningConfig =>
        {
            versioningConfig.AssumeDefaultVersionWhenUnspecified = true;
        });
    
        //snip
    }
