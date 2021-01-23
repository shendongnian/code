    var container = new UnityContainer();
    container.RegisterInstance<IData>("Product", myProductInstance); 
    container.RegisterInstance<IData>("Customer", myCustomerInstance);
    
    container.RegisterType<Func<string, IData>>(
        new InjectionFactory(c => new Func<string, IData>(name => c.Resolve<IData>(name)))
    );
