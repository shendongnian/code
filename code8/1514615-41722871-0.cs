    static class Extensions {
      public static SafeArrayReader<T> MakeSafe<T>(this T[] items)
      {
        return new SafeArrayReader<T>(items);
      }
    }
    struct SafeArrayReader<T> 
    {
      private T[] items;
      public SafeArrayReader(T[] items) { this.items = items; }
      public T this[int index] 
      {
        get
        {
          if (items == null || index < 0 || index >= items.Length)
            return default(T);
          return items[index];
        }
      }
    }
