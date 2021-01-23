    public static class ListExtensions
    {
          public static IList<T> CloneList<T>(this IList<T> source)
               where T : ICloneable
               => source.Select(o => (T)o.Clone()).ToList(); 
    }
