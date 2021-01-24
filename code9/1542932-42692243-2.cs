    public static void ConfigureMobileApp(IAppBuilder app)
    {
        HttpConfiguration config = new HttpConfiguration();
        new MobileAppConfiguration()
            .AddMobileAppHomeController()
            .MapApiControllers() //provides custom API capabilities for WebAPI controllers decorated with the [MobileAppController] attribute
            .ApplyTo(config);
        app.UseWebApi(config);
    }
