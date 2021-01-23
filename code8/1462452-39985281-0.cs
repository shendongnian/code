    public static IEnumerable<T[]> Something<T>(this IEnumerable<T> source, int count) {
      if (null == source)
        throw new ArgumentNullException("source");
      else if (count <= 0)
        throw new ArgumentOutOfRangeException("count");
      int c = source.Count();
      int size = c / count + (c % count > 0 ? 1 : 0);
      int large = count - count * size + c;    
      using (var en = source.GetEnumerator()) {
        for (int i = 0; i < count; ++i) {
          T[] chunk = new T[i < large ? size : size - 1];
          for (int j = 0; j < chunk.Length; ++j) {
            en.MoveNext();
            chunk[j] = en.Current;
          }
          yield return chunk;
        }
      }
    }
....
    var array = new int[] { 1, 2, 3, 4 };
    string result = string.Join(", ", array
      .Something(5)
      .Select(item => $"[{string.Join(", ", item)}]"));
    // [1], [2], [3], [4], []
    Console.Write(result);
