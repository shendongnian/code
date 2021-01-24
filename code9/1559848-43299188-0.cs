    class Generator
    {
         public static int UniqueId = 0;
         public static int GetNextId()
         {
              return Interlocked.Increment(ref UniqueId);
         }
    }
