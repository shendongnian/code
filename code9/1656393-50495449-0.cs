    IEnumerable<Type> assemblyTypeList;
    switch (pAssemblyMethodType)
    {
        case AssemblyMethodType.CallingAssembly:
            assemblyTypeList = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(c => c.IsClass
                    && !c.IsAbstract
                    && !c.ContainsGenericParameters);
            break;
        case AssemblyMethodType.ExecutingAssembly:
            assemblyTypeList = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(c => c.IsClass
                    && !c.IsAbstract
                    && !c.ContainsGenericParameters);
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(pAssemblyMethodType), pAssemblyMethodType, null);
    }
            
