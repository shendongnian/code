    public static class RegistrationExtensions
    {
        public static IRegistrationBuilder<TValidator, ConcreteReflectionActivatorData, SingleRegistrationStyle> 
            RegisterValidator<TValidator, TViewModel>(this ContainerBuilder builder)
        {
            return builder.RegisterType<TValidator>()
                          .As<IValidator<TViewModel>>()
                          .PropertiesAutowired()
                          .InstancePerLifetimeScope();
        }
    }
