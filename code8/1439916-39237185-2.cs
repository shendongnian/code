    public static class ObjectExtensions
    {
         public static T MapIfNotNull<T, TReturn>(this T source, Func<T, TReturn, TReturn> map)
                where T : class, new()
         {
              Contract.Requires(map != null);
              TReturn target = new TReturn();
              return some != null ? map(source, target) : null;
         }
    }
