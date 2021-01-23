    private List<List<int>> ToListOfPrimes(int value, List<int> parts = null) {
      if (null == parts)
        parts = new List<int>();
      List<List<int>> result = new List<List<int>>();
      if (value == 0) {
        result.Add(parts.ToList());
        return result;
      }
      int minPrime = parts.Count <= 0 ? 0 : parts[parts.Count - 1];
      if (value <= minPrime)
        return result;
      // not that efficient: binary search will be a better choice here 
      for (int i = 0; i < primes.Length; ++i) {
        int p = primes[i];
        if (p <= minPrime)
          continue;
        else if (p > value)
          break;
        var list = parts.ToList();
        list.Add(p);
        var outcome = ToListOfPrimes(value - p, list);
        foreach (var solution in outcome)
          result.Add(solution);
      }
      return result;
    }
