    private static IEnumerable<Tuple<int, int>> ScanLine<T>(IEnumerable<T> source, T sample, int atLeast) {
      int count = 0;
      int index = -1;
      foreach (var item in source) {
        index += 1;
        if (Object.Equals(item, sample))
          count += 1;
        else {
          if (count >= atLeast)
            yield return new Tuple<int, int>(index - count, index - 1);
          count = 0;
        }
      }
      if (count >= atLeast) 
        yield return new Tuple<int, int>(index - count + 1, index);
    }
    private static IEnumerable<Tuple<Point, Point>> ScanBoard<T>(T[,] source, T sample, int atLeast) {
      // Lines scan
      for (int i = 0; i < source.GetLength(0); ++i) {
        var line = Enumerable.Range(0, source.GetLength(1)).Select(c => source[i, c]);
        foreach (var item in ScanLine(line, sample, atLeast))
          yield return new Tuple<Point, Point>(new Point(item.Item1, i), new Point(item.Item2, i));
      }
      // Columns scan
      for (int i = 0; i < source.GetLength(1); ++i) {
        var line = Enumerable.Range(0, source.GetLength(0)).Select(r => source[r, i]);
        foreach (var item in ScanLine(line, sample, atLeast))
          yield return new Tuple<Point, Point>(new Point(i, item.Item1), new Point(i, item.Item2));
      }
    }
