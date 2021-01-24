    public static IEnumerable<IEnumerable<int>> GroupConsecutive(
      this IEnumerable<int> iterable, Func<int, int>? ordering = null) => 
        iterable
          .Select((e, i) => (e, i))
          .GroupBy(
            t => t.i - (ordering ?? (n => n))(t.e),
            (k,tg) => tg.Select(t => t.e));
