    public static bool TryGetFirst<T>(this IEnumerable<T> source, out T first)
    {
      using (var e = source.GetEnumerator())
      {
        if (e.MoveNext())
        {
          first = e.Current;
          return true;
        }
      }
      first = default(T);
      return false;
    }
