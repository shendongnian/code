    config.Scan(assembly =>
    {
        assembly.AssemblyContainingType(typeof(AuthenticationProvider));
        assembly.ConnectImplementationsToTypesClosing(typeof(IAuthenticationProvider<>));
    });
