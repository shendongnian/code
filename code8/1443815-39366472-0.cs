    static void Main(string[] args)
    {            
        UnityServiceLocator locator = new UnityServiceLocator(ConfigureUnityContainer(
        ServiceLocator.SetLocatorProvider(() => locator);
     
        var a = ServiceLocator.Current.GetInstance<IFoo>();
        var b = ServiceLocator.Current.GetInstance<IFoo>();
     
        Console.WriteLine(a.Equals(b));            
    }
     
    private static IUnityContainer ConfigureUnityContainer()
    {
        UnityContainer container = new UnityContainer();
        container.RegisterType<IFoo, Foo>(new ContainerControlledLifetimeManager());
        return container;
    }
