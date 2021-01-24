    container.RegisterType<ControllerA, ControllerA>(
        new InjectionConstructor(                        // Explicitly specify a constructor
            new ResolvedParameter<HttpClient>("ClientA") // Resolve parameter of type HttpClient using name "ClientA"
        )
    );
    container.RegisterType<ControllerB, ControllerB>(
        new InjectionConstructor(                        // Explicitly specify a constructor
            new ResolvedParameter<HttpClient>("ClientB") // Resolve parameter of type HttpClient using name "ClientB"
        )
    );
