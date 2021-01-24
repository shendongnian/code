    public static IRegistrationBuilder<TImplementer, ConcreteReflectionActivatorData, SingleRegistrationStyle> 
        RegisterTypeAsExternallyOwned<TImplementer>(this ContainerBuilder builder)
    {
        return builder.RegisterType<TImplementer>().ExternallyOwned();
    }
