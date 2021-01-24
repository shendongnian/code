    class GenericClass<T> where T : new()
    {
      public static T GetOne()
      {
        return new T();
      }
    }
