    public static string RandomString(int characters) {
      if (characters < 0)
        throw new ArgumentOutOfRangeException("characters");
      return string.Concat(Enumerable
        .Range(0, 10)
        .Select(i => (char)(s_Random.Next('z' - 'a' + 1) + 'a')));
    }
