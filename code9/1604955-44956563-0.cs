    bool IsAssemblyExists(string assemblyName)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
           if (assembly.FullName.StartsWith(assemblyName))
              return true;
        }
        return false;
    }
