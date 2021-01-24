      string source = @"1*2*5*9";
      // If user is supposed to input integers numbers and delimiters
      var delimiters = Regex
        .Split(source, "-?[0-9]+")
        .Select(item => item.Trim())
        .Where(item => !string.IsNullOrEmpty(item))
        .Distinct()
        .ToArray();
     Console.Write(string.Join(Environment.NewLine, delimiters)); 
