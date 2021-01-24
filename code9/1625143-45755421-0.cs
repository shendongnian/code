    public IEnumnerable<string> GetClassNames()
    {
        List<string> baseClassNames = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(assembly => assembly.GetTypes())
           .Where(type => type?.IsSubclassOf(typeof(BaseClass)) == true)
           .Select(type => type.FullName)
           .ToList();
        return baseClassNames;
    }
