    foreach (var mRef in project.MetadataReferences)
    {
        Type[] assemblyTypes;
        if (!File.Exists(mRef.Display))
            continue;
        try
        {
            assemblyTypes = Assembly.ReflectionOnlyLoadFrom(mRef.Display)
                                    .GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            assemblyTypes = e.Types
                             .Where(type => type != null)
                             .ToArray();
        }
        // ....
    }
