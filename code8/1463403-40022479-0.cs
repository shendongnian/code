    private static IEnumerable<Type> MatchingTypesFromDll<TBaseType>(string dllPath)
    {
       var type = typeof(TBaseType);
       try
       {
          var hasTypes = Mono.Cecil.AssemblyDefinition
              .ReadAssembly(dllPath)
              .Modules
              .Any
              (m =>
               {
                  var td = m.Import(type).Resolve();
                  return m.GetTypes().Any(t => td.IsAssignableFrom(t));
               });
        
          if (hasTypes)
          {
              var assembly = Assembly.LoadFrom(dllPath);
              return assembly
             .GetExportedTypes()
             .Where(TypeSatisfies<TBaseType>);
          }
          else
          {
              return new Type[] {};
          }
       }
       catch (Exception)
       {
          return new Type[] { };
       }
    
    }
   
