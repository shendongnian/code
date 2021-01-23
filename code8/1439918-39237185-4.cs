    public static class ObjectExtensions
    {
         public static T MapIfNotNull<T, TReturn>(this T source, Func<T, TReturn, TReturn> map)
                where TReturn : class, new()
         {
              Contract.Requires(map != null);
              if(source == null)
                 return;
              TReturn target = map(source, new TReturn());
              return target;
         }
    }
