    private static long GetDivisorsSum(long value, IList<int> primes) {
      HashSet<long> hs = new HashSet<long>();
      IList<long> divisors = GetPrimeDivisors(value, primes);
      ulong n = (ulong) 1;
      n = n << divisors.Count;
      long result = 1;
      for (ulong i = 1; i < n; ++i) {
        ulong v = i;
        long p = 1;
        for (int j = 0; j < divisors.Count; ++j) {
          if ((v % 2) != 0)
            p *= divisors[j];
          v = v / 2;
        }
        if (hs.Contains(p))
          continue;
        result += p;
        hs.Add(p);
      }
      return result;
    }
