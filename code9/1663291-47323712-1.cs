    private void ConfigWebApi(IAppBuilder app) {
        HttpConfiguration conf = new HttpConfiguration();
        WebApiConfig.Register(conf);
        // CORS
        app.UseCors(CorsOptions.AllowAll);
        app.UseWebApi(conf);
    }
