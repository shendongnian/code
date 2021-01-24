    static class ListExtensions
    {
       public static IEnumerable<string> AsStrings(this List<object> values)
       {
          return values.Select(v => v.ToString());
       }
    }
