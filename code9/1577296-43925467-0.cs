    Type[] types = Assembly.GetAssembly(typeof(int))
                           .GetTypes()
                           .Where(t => t.GetInterfaces().Any(i => i.Name == "ICollection"))
                           .ToArray();
    foreach (var type in types)
    {
        Console.WriteLine(type.Name);
    }
