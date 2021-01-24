    // have to return as object (not T), because we have two different classes
    public List<(Assembly asm, object instance, bool isDynamic)> FindLoadedTypes<T>()
    {
        var matches = from asm in AppDomain.CurrentDomain.GetAssemblies()
                      from type in asm.GetTypes()
                      where type.FullName == typeof(T).FullName
                      select (asm,
                          instance: Activator.CreateInstance(type),
                          isDynamic: asm.GetCustomAttribute<GeneratedCodeAttribute>() != null);
        return matches.ToList();
    }
    var loadedTypes = FindLoadedTypes<Apple>();
