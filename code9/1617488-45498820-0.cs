    var serviceType = typeof(IService);
        var allTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => serviceType.IsAssignableFrom(x))
            .ToList();
