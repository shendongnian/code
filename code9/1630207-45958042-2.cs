    var interfaces = typeof(Class).GetInterfaces()
        .ToDictionary(i => i.FullName, i => i.GetProperties().Select(p => p.Name).ToList());
    var properties = typeof(Class).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);
    
    // explicitly implemented properties
    foreach (var pi in properties.Where(pi => pi.Name.Contains(".")))
    {
        Console.WriteLine($"Explicitly implemented property {pi.Name} found.");
        var parts = pi.Name.Split('.');
        string interfaceName = string.Join(".", parts.Take(parts.Length - 1));
        string propertyName = parts[parts.Length - 1];
        interfaces[interfaceName].Remove(propertyName);
    }
    
    // rest
    foreach (var pi in properties.Where(pi => !pi.Name.Contains(".")))
    {
        // instead of this, you could also use LINQ and SelectMany
        // on the Values to check for containment
        bool found = false;
        foreach (var interfaceName in interfaces.Keys)
        {
            if (interfaces[interfaceName].Contains(pi.Name))
            {
                found = true;
                Console.WriteLine($"Found property {pi.Name} in interface {interfaceName}.");
            }
        }
    
        if (!found)
        {
            Console.WriteLine($"Property {pi.Name} is self-defined.");
        }
    }
