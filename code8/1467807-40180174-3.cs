    public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                
    
                var constraintsResolver = new DefaultInlineConstraintResolver();
    
                constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
    
                config.MapHttpAttributeRoutes(constraintsResolver);
    
                config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
    
              
    
            }
        }
