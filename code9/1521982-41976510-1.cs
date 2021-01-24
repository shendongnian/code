       private static IEnumerable<Type> MatchingTypesFromDll<TBaseType>(string dllPath)
        {
            try
            {
  
                return Assembly
                    .LoadFrom(dllPath)
                    .GetExportedTypes()
                    .Where(TypeSatisfies<TBaseType>);
          
            }
            catch (Exception e)
            {
                    Debug.WriteLine($"Exception {e} when trying to load from {dllPath}");
                    return new Type[] {};
            }
        }
