    var input = "'x,y',2,4,'y,z'";
    var parts = Regex
      .Matches(input, "'.*?'|[^,]+")
      .Cast<Match>()
      .Select(m => m.Value)
      .ToList();
    Console.WriteLine(string.Join(Environment.NewLine, parts));
