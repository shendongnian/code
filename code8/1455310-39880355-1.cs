    public class QueryHandlerRegistrationSource : IRegistrationSource
    {
        public Boolean IsAdapterForIndividualComponents
        {
            get
            {
                return false;
            }
        }
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            Type serviceType = (service as IServiceWithType)?.ServiceType;
            if (serviceType == null)
            {
                yield break;
            }
            if (serviceType.IsGenericType && serviceType.GetGenericTypeDefinition() == typeof(IQueryHandlerAsync<,>))
            {
                Type[] argumentTypes = serviceType.GetGenericArguments();
                Type t0 = argumentTypes[0];
                Type t1 = argumentTypes[1];
                if (t0 == typeof(Detailed))
                {
                    IComponentRegistration registration = RegistrationBuilder.ForType(typeof(DetailedQueryHandler<>).MakeGenericType(t1))
                                                                             .As(service)
                                                                             .CreateRegistration();
                    yield return registration;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
