	public static void Main()
    {
      string pattern =  "<your regex pattern>";
      string input = "<your html input>";
      string replacement = string.Empty;
      Regex rgx = new Regex(pattern);
      string result = rgx.Replace(input, replacement);
      Console.WriteLine("Original String:    '{0}'", input);
      Console.WriteLine("Replacement String: '{0}'", result);                             
    }
	
