    var type = typeof(IConfigInterface);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => type.IsAssignableFrom(p));
    foreach (var item in types)
    {
        classes.Add(Activator.CreateInstance(item));    
    }
