    IEnumerable<Assembly> GetCallingAssemblies()
    {
        var s = new StackTrace();
        return s.GetFrames()
            .Select(x => x.GetMethod().DeclaringType.GetTypeInfo().Assembly)
            .Where(x => !Equals(x, GetType().GetTypeInfo().Assembly))
            .Where(x => !x.FullName.StartsWith("Microsoft."))
            .Where(x => !x.FullName.StartsWith("System."));
    }
    Assembly GetCallingAssembly()
    {
        return GetCallingAssemblies().First();
    }
