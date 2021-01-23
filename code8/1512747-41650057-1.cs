    IEnumerable<ISearchThisInterface> instances =
        Assembly.GetExecutingAssembly()
            .GetTypes()  // Gets all types
            .Where(type => typeof(ISearchThisInterface).IsAssignableFrom(type)) // Ensures that object can be cast to interface
            .Where(type => 
                !type.IsAbstract && 
                !type.IsGenericType &&
                type.GetConstructor(new Type[0]) != null) // Ensures that type can be instantiated
            .Select(type => (ISearchThisInterface)Activator.CreateInstance(type)) // Create instances
            .ToList();
    foreach (ISearchThisInterface instance in instances)
    {
        instance.AMethod();
    }
