    Assembly myassembly = Assembly.ReflectionOnlyLoadFrom(NewtonSoftDllPath);
    foreach (Type type in myassembly.GetTypes())
    {
        Console.WriteLine(type.FullName);
    }
