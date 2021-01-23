    public static IEnumerable<T> BreadthFirst<T>(this IEnumerable<T> source,
                                                 Func<T, IEnumerable<T>> children) {
      if (Object.ReferenceEquals(null, source))
        throw new ArgumentNullException(nameof(source));
      else if (Object.ReferenceEquals(null, children))
        throw new ArgumentNullException(nameof(children));
      HashSet<T> proceeded = new HashSet<T>();
      Queue<IEnumerable<T>> queue = new Queue<IEnumerable<T>>();
      queue.Enqueue(source);
      while (queue.Count > 0) {
        IEnumerable<T> src = queue.Dequeue();
        if (Object.ReferenceEquals(null, src))
          continue;
        foreach (var item in src) 
          if (proceeded.Add(item)) {
            yield return item;
            queue.Enqueue(children(item));
          }
      }
    }
