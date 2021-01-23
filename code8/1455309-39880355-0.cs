    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle> AsQueryHandler<TLimit, TConcreteActivatorData>(this IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle> registration)
            where TConcreteActivatorData : IConcreteActivatorData
        {
            Type queryHandlerType = registration.ActivatorData.Activator.LimitType;
            Type queryHandlerRegistrationType = queryHandlerType.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandlerAsync<,>));
            if (queryHandlerRegistrationType == null)
            {
                throw new ArgumentException($"{queryHandlerType} doesn't implement {typeof(IQueryHandlerAsync<,>).Name} interface");
            }
            TypedService queryHandlerService = new TypedService(queryHandlerRegistrationType);
            return registration.As(queryHandlerService);
        }
    }
