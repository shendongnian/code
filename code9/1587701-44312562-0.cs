    private static Dictionary<string, string> dict;
    static void Main(string[] args)
    {
      dict =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
          {
            { "hello", "Hi" },
            { "world", "people" },
            { "apple", "fruit" }
          };
    
      var input = "<a>hello</a> <b>hello world</b> apple <c>I like apple</c> hello";
      var pattern = @"<.>([^<>]+)<\/.>";
      var output = Regex.Replace(input, pattern, Replacer);
    
      Console.WriteLine(output);
      Console.ReadLine();
    }
    
    static string Replacer(Match match)
    {
      var value = match.Value;
      foreach (var kvp in dict)
      {
        if (value.Contains(kvp.Key)) value = value.Replace(kvp.Key, kvp.Value);
      }
      return value;
    }
