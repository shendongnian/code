    public static IEnumerable<SomeGenericType<M>> append_list<T, M>(T a, T b) 
         where T : IEnumerable<SomeGenericType<M>>
    {
          ...
    }
