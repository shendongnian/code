    public static IEnumerable<T[]> SlidingWindow<T>(this IEnumerable<T> source,
                                                    int windowSize) {
      if (null == source)
        throw new ArgumentException("source");
      else if (windowSize <= 0)
        throw new ArgumentOutOfRangeException("windowSize", 
          "Window size must be positive value");
      List<T> window = new List<T>(windowSize);
      foreach (var item in source) {
        if (window.Count >= windowSize) {
          yield return window.ToArray();
          window.RemoveAt(0);
        }
        
        window.Add(item);
      }
      if (window.Count > 0)
        yield return window.ToArray();
    }
...
    var sentence = "Regex for taking out words out of a string from a specific position";
    // Get all matches as usual...
    var result = Regex
      .Matches(sentence, @"[\w\-]+") // you don't want ^ anchor
      .OfType<Match>()
      .Select(match => match.Value)
      .SlidingWindow(3); // and represent them as sliding windows..
    var test = String.Join(Environment.NewLine, result
      .Select(line => $"[{string.Join(" ", line)}]")); 
    Console.Write(test);
