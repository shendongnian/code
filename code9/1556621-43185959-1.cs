    public static partial class EnumerableExtensions {
      public static IEnumerable<T> Tail<T>(this IEnumerable<T> source, int count) {
        if (null == source)
          throw new ArgumentNullException("source");
        else if (count < 0)
          throw new ArgumentOutOfRangeException("count");
        else if (0 == count)
          yield break;
        Queue<T> queue = new Queue<T>(count + 1);
        foreach (var item in source) {
          queue.Enqueue(item);
          if (queue.Count > count)
            queue.Dequeue();
        }
        foreach (var item in queue)
          yield return item;
      }
    }
...
    var lastTwolines = File
      .ReadLines("C:\\test.log") // Not all lines
      .Tail(2);
