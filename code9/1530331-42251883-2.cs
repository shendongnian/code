    static class MyExtensions 
    {
      public static bool Any(this IEnumerable sequence) 
      {
         if (sequence == null) 
           throw new ArgumentNullException ... etc ...
         if (sequence is ICollection)
           return ((ICollection)sequence).Any();
         foreach(object item in sequence)
           return true;
         return false;
       }
       public static bool Any(this ICollection collection)
       {
          if (collection == null) blah blah blah
          return collection.Count > 0;
       }
    }
