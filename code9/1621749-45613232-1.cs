    public IEnumerable<IGrouping<Type, Type>> FindGroups(Assembly assembly, Type @interface)
    {
        return assembly.GetTypes()
            .Where(t => @interface.IsAssignableFrom(t) 
                && t.BaseType != null
                && t.BaseType.IsAbstract)
            .Select(t => new {baseType = t.BaseType, type = t})
            .GroupBy(x => x.baseType, x => x.type);
    }
