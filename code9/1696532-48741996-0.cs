    container.RegisterType<ILog, Log>();
    container.RegisterType<IResolver, Resolver>();
    container.RegisterType<IProvider, Provider>();
    container.RegisterType<MyClass>(new InjectionConstructor(
    	new ResolvedParameter<ILog>(),
    	new ResolvedParameter<IProvider>(),
    	new ResolvedParameter<IResolver>(),
    	typeof(ItemTypeEnum)));                
    
    MyClass mc = container.Resolve<MyClass>(new ParameterOverride("itemType", ItemTypeEnum.Value));
