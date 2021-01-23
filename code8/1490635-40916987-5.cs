    var classType = loadedAssemblies
                .Where(a => a != null && a.FullName.StartsWith("MY."))
                .SelectMany(a => a.GetTypes())
                .Distinct()
                .ToArray()[0];
    
    var curObject = MyFactory.MyCreateInstance<object>(classType);
