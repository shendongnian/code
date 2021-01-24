    public void ConfigureDesignTimeServices(IServiceCollection services)
    {
        throw new Exception("works");
        services.AddSingleton<IPluralizer, MyPluralizer>();
    }
