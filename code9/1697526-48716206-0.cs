    // can throw a ReflectionTypeLoadException in case not all dlls are known
    private static IEnumerable<Type> GetImplementationsOf<TInterface>() {
      var interfaceType = typeof( TInterface );
      return AppDomain.CurrentDomain.GetAssemblies()
        .Select( assembly => assembly.GetTypes().Where( type => !type.IsInterface && interfaceType.IsAssignableFrom( type ) ) )
        .SelectMany( implementation => implementation );
    }
