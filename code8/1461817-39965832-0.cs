        protected void Application_Start()
        {
            var specificControllerTypes = new[]
            {
                typeof(Mocks.XController)
            };
            var config = GlobalConfiguration.Configuration;
            config.Services.Replace(
                typeof(IHttpControllerTypeResolver),
                new DefaultHttpControllerTypeResolver(type => 
                    type.IsVisible &&
                    !type.IsAbstract &&
                    typeof(IHttpController).IsAssignableFrom(type) &&
                    type.Name.EndsWith(DefaultHttpControllerSelector.ControllerSuffix) &&
                    !specificControllerTypes.Any(t => t != type && t.Name == type.Name)
                )
            );
