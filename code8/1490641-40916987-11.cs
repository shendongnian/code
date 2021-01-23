    var classType = loadedAssemblies
                .Where(a => a != null && a.FullName.StartsWith("MY."))
                .SelectMany(a => a.GetTypes())
                .Distinct()
                .ToArray()[0];
    
    var curObject = MyFactory.MyCreateInstance(classType);
    // This will return an array of values
    object[] values = classType
                     .GetFields()
                     .Select(f => f.GetValue(curObject))
                     .ToArray();
