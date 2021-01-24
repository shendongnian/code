    container.RegisterType<Func<IOne, ITwo, IApp>>(
        new InjectionFactory(c =>
            new Func<IOne, ITwo, IApp>((iOne, iTwo) =>
                c.Resolve<IApp>(
                    new ParameterOverride("NameOfIOneParameter", iOne),
                    new ParameterOverride("NameOfITwoParameter", iTwo)))));
