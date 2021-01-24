    public override void Configure(Funq.Container container)
    {
        SetConfig(new HostConfig {
            HandlerFactoryPath = "api",
        });
    
        //this is the configuration for Hijacking prevention
        SuppressFormsAuthenticationRedirectModule.PathToSupress = Config.HandlerFactoryPath;
    }
