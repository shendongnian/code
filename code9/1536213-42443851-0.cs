    public static IEnumerable<R> AggregateSequence<A, R>(
      this IEnumerable<A> items,
      Func<A, R, R> aggregator,
      R initial)
    {
      // Error cases go here.
      R result = initial;
      foreach(A item in items)
      {
        result = aggregator(item, result);
        yield return result;
      }
    }
