    public void Configuration(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();   
                ConfigureOAuth(app);    
                WebApiConfig.Register(config);
                app.UseWebApi(config);
            }
