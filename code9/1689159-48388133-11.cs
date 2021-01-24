    public static IEnumerable<IEnumerable<int>> GroupConsecutive(
      this IEnumerable<int> iterable, Func<int,int> ordering = null) {
        ordering = ordering ?? (n => n);
        foreach (var tg in iterable
                             .Select((e, i) => (e, i))
                             .GroupBy(t => t.i - ordering(t.e)))
            yield return tg.Select(t => t.e);
    }
