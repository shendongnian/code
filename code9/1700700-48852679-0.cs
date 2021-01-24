    Assembly assembly = typeof(UserMapper).Assembly;
    foreach (var type in assembly.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract))
    {
        foreach (var i in type.GetInterfaces())
        {
            if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapper<,>))
            {
                services.AddTransient(typeof(IMapper<,>), type);
            }
        }
    }
