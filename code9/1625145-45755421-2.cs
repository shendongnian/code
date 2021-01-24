    public IEnumnerable<Type> GetBaseClassSubTypesInCurrrentAssenblies()
    {
        List<Type> baseClassTypes = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(assembly => assembly.GetTypes())
           .Where(type => type?.IsSubclassOf(typeof(BaseClass)) == true)
           .ToList();
        return baseClassTypes;
    }
