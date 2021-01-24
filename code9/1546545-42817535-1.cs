    public static class CollectionExtensions
    {
       public static Boolean Contains(this ICollection collection, Object item)
       {
          for (Object o in collection)
          {
             if (o == item)
                return true;
          }
          return false;
       }
    }
