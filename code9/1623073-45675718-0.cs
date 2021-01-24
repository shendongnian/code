      string[] tests = new string[] {
        "standard=def",
        "empty=",
        "null",
        "pipe=18|2",
        "pipe_doubled=123||444",
        "pipe_triple=789|||987",
        "pipe|name|null",
      };
      foreach (var item in tests) {
        string value = item;
        int index = value.IndexOf('=');
        if (index >= 0)
          value = value.Substring(index + 1);
        value = Regex.Replace(
           value, 
         @"\|+", 
           match => match.Length > 1 
             ? match.Value // stacked paipes
             : " | ");     // single pipe
        Console.WriteLine(value);
      }
