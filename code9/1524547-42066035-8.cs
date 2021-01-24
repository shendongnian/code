     public static class AnimalsTypeProvider
     {
            public static IEnumerable<Type> GetAnimalsTypes(ICustomAttributeProvider provider)
            {
                var allAnimalTypes = GetAllTypeFromAssembly(AppDomain.CurrentDomain.GetAssemblies(), typeof(IAnimal));
                return allAnimalTypes;
            }           
    
            private static IEnumerable<Type> GetAllTypeFromAssembly(Assembly assembly, Type targetType)
            {
                var allTypes = assembly.GetTypes();
    
                var alltypesThaImplementTarget =
                    allTypes.Where(t => (false == t.IsAbstract) && t.IsClass && targetType.IsAssignableFrom(t));
                return alltypesThaImplementTarget;
            }
      }
