    public static void InitializeInjector(this IAppBuilder app, IDataProtectionProvider DataProtectionProvider)
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        container.Options.PropertySelectionBehavior = new PropertySelectionBehavior<InjectAttribute>();
    
        InitializeContainer(container, DataProtectionProvider); // Here
        app.UseOwinContextInjector(container);
        app.MapSignalR(container);
    
        container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
        container.Verify();
        DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
    
        BinderConfig.RegisterModelBinders(container);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
    }
