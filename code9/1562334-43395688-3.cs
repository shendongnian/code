    container.RegisterType<Func<string, string, IApp>>(
        new InjectionFactory(c =>
            new Func<string, string, IApp>((iOneNamedRegistration, iTwoNamedRegistration) =>
                c.Resolve<IApp>(
                    new ParameterOverride("NameOfIOneParameter", c.Resolve<IOne>(iOneNamedRegistration)),
                    new ParameterOverride("NameOfITwoParameter", c.Resolve<ITwo>(iTwoNamedRegistration))))));
