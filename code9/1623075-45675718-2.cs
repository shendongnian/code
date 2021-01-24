    private static string Builder(string source) {
      if (string.IsNullOrEmpty(source))
        return source;
      StringBuilder result = new StringBuilder();
      for (int i = 0; i < source.Length; ++i) {
        char current = source[i];
        if (i > 0) {
          char prior = source[i - 1];
          if (char.IsLetter(prior) && char.IsDigit(current) ||
              char.IsLetterOrDigit(prior) && char.IsUpper(current))
            result.Append(' ');
        }
        result.Append(current);
      }
      return result.ToString();
    }
