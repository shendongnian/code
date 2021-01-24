    internal static IEnumerable<string> GetStrings(string input)
    {
      var values = "1234";
      var index = input.IndexOf('@');
      if (index == -1) return new []{ input };
      return 
          values
          .Select(ReplaceFirstWildCardWithValue)
          .SelectMany(GetStrings);
      string ReplaceFirstWildCardWithValue(char value) => input.Substring(0, index) + value + input.Substring(index + 1);
    }
