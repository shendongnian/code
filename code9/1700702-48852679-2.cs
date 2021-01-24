    Assembly assembly = typeof(UserMapper).Assembly;
    foreach (var type in assembly.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract))
    {
        foreach (var i in type.GetInterfaces())
        {
            if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapper<,>))
            {
                // NOTE: Due to a limitation of Microsoft.DependencyInjection we cannot 
                // register an open generic interface type without also having an open generic 
                // implementation type. So, we convert to a closed generic interface 
                // type to register.
                var interfaceType = typeof(IMapper<,>).MakeGenericType(i.GetGenericArguments());
                services.AddTransient(interfaceType, type);
            }
        }
    }
