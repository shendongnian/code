    private static IEnumerable<List<T>> MyEnumerator<T>(List<List<T>> data) {
      List<int> indexes = Enumerable.Repeat(0, data.Count).ToList();
      do {
        yield return indexes
          .Select((value, i) => data[i][value])
          .ToList();
        for (int i = data.Count - 1; i >= 0; --i)
          if (indexes[i] == data[i].Count - 1)
            indexes[i] = 0;
          else {
            indexes[i] += 1;
            break;
          }
      }
      while (indexes.Any(value => value != 0));
    }
