    services.TryAddSingleton<IX, A>(); // adds A
    services.TryAddSingleton<IX, B>(); // does not add B, because of A
    IX x = container.GetService<IX>(); // resolves A
    
    services.TryAddSingleton <IX, A>(); // adds A
    services.TryAddSingleton <IX, B>(); // does not add B, because of A
    IEnumerable<IX> xs = container.GetServices<IX>(); // resolves A
