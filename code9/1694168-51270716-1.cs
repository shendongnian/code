    container.RegisterConditional<IDatabase, FirstSubDatabase>(
        Lifestyle.Scoped,
        c => c.Consumer.ImplementationType.FullName?.StartsWith(
            "external.lib.", StringComparison.OrdinalIgnoreCase) ?? false);
    
    container.RegisterConditional<IDatabase, SecondSubDatabase>(
        Lifestyle.Scoped,
        c => c.Consumer.ImplementationType == typeof(LocalConsumerClass));
