    public static IEnumerable<T> BeforeLastMatch<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return BeforeLastMatchImpl(source, predicate);
    }
    public static IEnumerable<T> BeforeLastMatchImpl<T>(IEnumerable<T> source, Func<T, bool> predicate)
    {
      var buffer = new List<T>();
      foreach(T item in source)
      {
        if (predicate(item) && buffer.Count != 0)
        {
          foreach(T allowed in buffer)
          {
              yield return allowed;
          }
          buffer.Clear();
        }
        buffer.Add(item);
      }
    }
