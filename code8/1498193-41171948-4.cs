    public static class FromObjectExtensions
    {
      public static IEnumerable<ToObject> ToToObject(this IEnumerable<FromObject> q)
      {
        return q.Select(t=>new ToObject
        {
           Property1=t.Property1,
           ...
        };
      }
    }
