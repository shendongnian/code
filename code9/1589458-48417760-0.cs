    public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            //configure your app
            config.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            SwaggerConfiguration.Configure(config);            
            appBuilder.UseWebApi(config);
        }
