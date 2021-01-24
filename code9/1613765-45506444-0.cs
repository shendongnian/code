    public void Configuration(IAppBuilder appBuilder)
    {
        // Enable Windows Authentification and Anonymous authentication
        HttpListener listener = 
        (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
        listener.AuthenticationSchemes = 
        AuthenticationSchemes.IntegratedWindowsAuthentication | 
        AuthenticationSchemes.Anonymous;
        HttpConfiguration config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();
        appBuilder.Use(typeof(WinAuthMiddleware));
        appBuilder.UseWebApi(config);
    }
