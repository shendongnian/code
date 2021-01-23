    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<ISomething, Something>();
        container.RegisterType<ISomething, SomethingMock>("SomethingMock");
    }
