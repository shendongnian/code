    private void ConfigWebApi(IAppBuilder app) {
        HttpConfiguration conf = new HttpConfiguration();
        WebApiConfig.Register(conf);
        app.UseWebApi(conf);
        // CORS
        app.UseCors(CorsOptions.AllowAll);
    }
