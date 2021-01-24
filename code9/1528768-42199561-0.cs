        public void Configuration(IAppBuilder app)
        {
            var container = new WindsorContainer().Install(new WindsorInstaller());
            container.Register(Component.For<IAppBuilder>().Instance(app));
            var httpDependencyResolver = new WindsorHttpDependencyResolver(container);
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = httpDependencyResolver;
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorControllerActivator(container));
            app.UseWebApi(config);
        }
