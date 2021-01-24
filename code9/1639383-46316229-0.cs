    public static IEnumerable<TValue> GetNonUniqueValues<TKey, TValue>(this IDictionary<TKey, TValue> source)
    {
      Dictionary<TValue, int> results = new Dictionary<TValue, int>();
      foreach (var kvp in source)
      {
        int count;
        if (results.TryGetValue(kvp.Value, out count))
        {
          count++;
        }
        else
        {
          count = 1;
        }
        results[kvp.Value] = count;
      }
      foreach (var kvp in results)
      {
        if (kvp.Value > 1)
        {
          yield return kvp.Key;
        }
      }
    }
