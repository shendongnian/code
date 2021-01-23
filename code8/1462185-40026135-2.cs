    public void Configuration(IAppBuilder app)
    {
        ConfigureAuth(app);
        app.InitializeInjector(app.GetDataProtectionProvider());
    }
