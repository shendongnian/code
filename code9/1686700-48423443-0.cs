    public static IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle>
        RegisterInstance<T, TServiceType>(this ContainerBuilder builder)
    {
        return builder.RegisterType<T>().As<TServiceType>().InstancePerLifetimeScope();
    }
    
    public static IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle>
        RegisterAutowiredInstance<T>(this ContainerBuilder builder)
    {
        return builder.RegisterType<T>().PropertiesAutowired().InstancePerRequest();
    }
    
    public static IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle>
        RegisterGenericInstance(this ContainerBuilder builder, Type type, Type serviceType)
    {
        return builder.RegisterGeneric(type).As(serviceType).InstancePerRequest();
    }
