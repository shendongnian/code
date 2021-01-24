       private static IEnumerable<Type> MatchingTypesFromDll<TBaseType>(string dllPath)
        {
            try
            {
                var c = true;
                if (c)
                        return Assembly
                            .LoadFrom(dllPath)
                            .GetExportedTypes()
                            .Where(TypeSatisfies<TBaseType>);
                else
                    return new Type[] {};
            }
            catch (Exception e)
            {
                    Debug.WriteLine($"Exception {e} when trying to load from {dllPath}");
                    return new Type[] {};
            }
        }
