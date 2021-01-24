    var interfaceBinderOptions = new TypeResolverOptions();
    interfaceBinderOptions.TypeResolverMap.Add(typeof(IFilterResolver<>), new List<Type> { typeof(QueryTreeNode<>), typeof(QueryTreeBranch<>) });
    var interfaceProvider = new InterfaceBinderProvider(interfaceBinderOptions);
    services.AddMvc(config => {
        config.ModelBinderProviders.Insert(0, interfaceProvider );
    });
