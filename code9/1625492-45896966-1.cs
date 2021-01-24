    void Configure(IAppBuilder app) {
        IPrincipal currentUser = null;
        Func<IPrincipal> activator = () => currentUser;
        // Create the container as usual.
        var container = new Container();
        //Only one instance will be created by the container per web request 
        //and the instance will be disposed when the web request ends.
        container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        // Register your types, for instance:
        container.Register<IUserContext>(() => new UserContext(activator),
            Lifestyle.Scoped);
        //...Configure respective DI as needed
        //Set MVC DI
        System.Web.Mvc.DependencyResolver
            .SetResolver(new SimpleInjectorDependencyResolver(container));
        //Set Web API DI
        System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
            new SimpleInjectorWebApiDependencyResolver(container);
        //Set SignalR DI 
        var config = new HubConfiguration();
        config.Resolver = new SignalRSimpleInjectorDependencyResolver(container);
        //...use other middleware 
        //...custom middleware to grab user (placed especially after Identity config)
        app.Use(async (context, next) => {
            //get the current user from request pipeline
            currentUser = context.Authentication.User;
            await next();
        });
        app.MapSignalR(config);
    }
