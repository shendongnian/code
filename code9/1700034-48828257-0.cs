    private static string Process(string value) {
      StringBuilder result = new StringBuilder();
      int prior = 0;
      int current = 0;
      bool first = true;     // 1st state flag - are we at the very start of the string
      bool suspend = false;  // 2nd state flag - are we in the interval a-b 
      foreach (string item in value.Split(',')) {
        current = int.Parse(item);
        if (!first && prior + 1 == current) 
          suspend = true;
        else {
          if (suspend)
            result.Append($"-{prior}");
          result.Append(result.Length > 0 ? $",{current}" : $"{current}");
          suspend = false;
        }
        first = false;
        prior = current;
      }
      if (suspend)
        result.Append($"-{prior}");
      return result.ToString();
    }
