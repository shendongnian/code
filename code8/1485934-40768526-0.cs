    private static IEnumerable<T> Merge<T>(params IEnumerable<T>[] sources) {
      List<IEnumerator<T>> enums = sources
        .Select(source => source.GetEnumerator())
        .ToList();
      try {
        while (enums.Any()) {
          for (int i = 0; i < enums.Count;)
            if (enums[i].MoveNext()) {
              yield return enums[i].Current;
              i += 1;
            }
            else {
              // exhauseted, let's remove enumerator
              enums[i].Dispose();
              enums.RemoveAt(i);
            }
        }
      }
      finally {
        foreach (var en in enums)
          en.Dispose();
      }
    }
