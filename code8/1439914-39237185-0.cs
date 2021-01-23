    public static class ObjectExtensions
    {
         public static T MapIfNotNull<T, TReturn>(this T some, Func<T, TReturn> map)
                where T : class
         {
              Contract.Requires(map != null);
              return some != null ? map(some) : null;
         }
    }
