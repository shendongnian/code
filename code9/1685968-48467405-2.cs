    Type GetContained(Type t)
    {
        return t.GetInterfaces()
                .Concat(new[] { t })
                .Where(x => x.IsGenericType)
                .Where(x => typeof(IContainer<>).IsAssignableFrom(x.GetGenericTypeDefinition()))
                .Select(x => x.GenericTypeArguments[0])
                .FirstOrDefault();
    }
