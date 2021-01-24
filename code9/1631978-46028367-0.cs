    var res = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(x => x.GetTypes())
        .Where(x =>
            !x.IsAbstract
        &&  !x.IsInterface
        &&  x.GetInterfaces().Any(i =>
                i.IsGenericType()
            &&  i.GetGenericTypeDefinition() == typeof(IOperator<,>)
            )
        ).Select(x => Activator.CreateInstance(x)).ToList();
