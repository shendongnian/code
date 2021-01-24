        public static IContainer Configure(IAppBuilder appBuilder, HttpConfiguration config)
        {
            var containerBuilder = new ContainerBuilder();
            .... registrations here ....
            var container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            return container;
        }
