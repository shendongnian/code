    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<INinjaContext, NinjaContext>(new PerRequestLifetimeManager());
        container.RegisterType<INinjaRepository, NinjaRepository>(new PerRequestLifetimeManager());
    }
