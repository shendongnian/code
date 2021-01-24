    private static IEnumerable<T> RepeatOnly<T>(IEnumerable<T> source, int times) {
      Dictionary<T, int> counts = new Dictionary<T, int>();
      foreach (var item in source) {
        int count;
        if (counts.TryGetValue(item, out count))
          counts[item] = ++count;
        else 
          counts.Add(item, count = 1);
        if (count <= times)
          yield return item;
      }
    }
....
    int[] source = new int[] { 1, 2, 3, 4, 1, 1, 2, 3 };
    int[] result = RepeatOnly(source, 2).ToArray(); 
    Console.Write(string.Join(Environment.NewLine, result));
    
