    container.ResolveUnregisteredType += (s, e) =>
    {
        Type serviceType = e.UnregisteredServiceType;
        if (serviceType.IsGenericType && 
            serviceType.GetGenericTypeDefinition() == typeof(IRepository<>))
        {
            Type implementationType = typeof(Repository<>)
                .MakeGenericType(serviceType.GetGenericArguments()[0]);
                
            Registration r = Lifestyle.Transient.CreateRegistration(
                serviceType,
                () => Activator.CreateInstance(implementationType, "connectionString"),
                container);
        
            e.Register(r);
        }
    };
    
