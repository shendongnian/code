    public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
    {
      IEnumerable<TResult> results = source as IEnumerable<TResult>;
      if (results != null)
        return results;
      // ... the rest of the method
    }
