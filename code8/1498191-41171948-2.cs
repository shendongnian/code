    public static class FromObjectExtensions
    {
      public static IQueryable<ToObject> ToToObject(this IQueryable<FromObject> q)
      {
        return q.Select(t=>new ToObject
        {
           Property1=t.Property1,
           ...
        };
      }
    }
