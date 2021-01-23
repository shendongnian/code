    static IEnumerable<PropertyInfo> GetPrpsInterfaces(Type type, BindingFlags flags)
    {
          if (!type.IsInterface)
               return type.GetProperties(flags);
    
          return (new Type[] { type }).Concat(type.GetInterfaces()).SelectMany(i => i.GetProperties(flags));
    }
