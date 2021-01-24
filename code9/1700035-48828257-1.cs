      string[] tests = new string[] {
        "1,2,3,4",
        "1,2,3,5",
        "1,2,3,6,7",
        "1,2,3,8,11,12",
        "1,3,8,11,12,14,21,22,23",
      };
      string report = string.Join(Environment.NewLine, tests
        .Select(item => $"{item, -25} -> {Process(item)}"));
      Console.WriteLine(report);
