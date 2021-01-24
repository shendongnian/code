    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IBaseClass, BaseClass>(); // Registering types
        container.LoadConfiguration();
    }
