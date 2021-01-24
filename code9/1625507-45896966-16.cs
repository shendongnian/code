    public void ConfigureSignalR(IAppBuilder app) {
        // Create the container as usual.
        var container = new Container();
        // Register your types, for instance:
        container.Register<IUserContextFactory,UserContextFactory>();    
        //Set SignalR DI
        var config = new HubConfiguration() {
            Resolver = new SignalRSimpleInjectorDependencyResolver(container);
        };
        app.MapSignalR(config);
    }
