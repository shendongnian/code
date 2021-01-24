      string source = @"1*2*5*9";
      // Main text pattent; if user is supposed to input integers numbers and delimiters
      string bodyPattern = 
        @"-?[0-9]+";
      var delimiters = Regex
        .Split(source, bodyPattern)
        .Select(item => item.Trim())
        .Where(item => !string.IsNullOrEmpty(item))
        .Distinct()
        .ToArray();
     Console.Write(string.Join(Environment.NewLine, delimiters)); 
