    static class ListExtensions
    {
       public static IEnumerable<string> ToStrings(this List<object> values)
       {
          return values.Select(v => v.ToString());
       }
    }
