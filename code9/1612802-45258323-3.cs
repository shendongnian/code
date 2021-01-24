    public static T CreateProcessor<T>()
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(r => r.GetTypes())
            .Where(r => type.IsAssignableFrom(T));
        var type = types.FirstOrDefault(); // Selecting first found implementor
        if (type == null)
            throw new ApplicationException("Unsupported type");
        
        return Activator.CreateInstance(type) as T;
    }
