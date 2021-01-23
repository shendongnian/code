    private static int Biggest(int value) {
      string st = value.ToString();
      if (value <= 1000000000)
        return int.Parse(string.Concat(st.OrderByDescending(c => c)));
      string max = int.MaxValue.ToString();
      List<int> digits = st.Select(c => c - '0').ToList();
      StringBuilder sb = new StringBuilder(9);
      bool exact = true;
      while (digits.Any()) {
        for (int i = 0; i < max.Length; ++i) {
          int digitToFind = max[i] - '0';
          int digitActual;
          digitActual = digits
            .Where(d => !exact || d <= digitToFind)
            .OrderByDescending(d => d)
            .First();
          if (exact)
            exact = digitActual == digitToFind;
          sb.Append(digitActual);
          digits.Remove(digitActual);
        }
      }
      return int.Parse(sb.ToString());
    }
