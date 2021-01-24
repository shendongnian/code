        public void Configuration(IAppBuilder app)
        {
            DemoController dummy = new DemoController();
        
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        
            app.UseWebApi(config);
        }
