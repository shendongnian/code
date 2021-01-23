    public static class ObjectExtensions
    {
         public static MyObject CreateMyObject(this string name)
         {
               Contract.Requires(!string.IsNullOrEmpty(name));
               // create and return object otherwise 
         }
    }
