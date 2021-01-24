      string source = "[-3*4+20-0.5/-4.1]";
      //TODO: specify the delimiters:
      // If you want more delimiters, e.g. (, ), [, ] etc. 
      // for, say, 9*[(456+789)/(95-2.96)-3]
      // just add them into the array
      char[] delimiters = new char[]  { '*', '+', '-', '/' };
      string pattern = "(" + string.Join("|", delimiters
        .Select(item => Regex.Escape(item.ToString()))) + ")";
      string[] result = Regex
        .Split(source.TrimStart('[').TrimEnd(']'), pattern) // (...) preserves delim
        .Select(item => item.Trim()) // <- if you want to trim each item 
        .Where(item => !string.IsNullOrEmpty(item))
        .ToArray();
      // -, 3, *, 4, +, 20, -, 0.5, /, -, 4.1
      Console.Write(string.Join(", ", result));
