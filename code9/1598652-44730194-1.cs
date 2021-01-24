    var container = new UnityContainer();
    
    container
        .RegisterType<IA, C>(typeof(IA).Name, new InjectionConstructor(1))
        .RegisterType<IB, C>(typeof(IB).Name, new InjectionConstructor(2));
    
    var a = container.Resolve<IA>(typeof(IA).Name);
    
    a.X.ShouldBe(1); // will be 1
