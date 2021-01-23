        public void Configuration(IAppBuilder app)
        {
            var userIdProvider = new ZumoUserIdProvider();
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => userIdProvider);
            ConfigureMobileApp(app);
        }
