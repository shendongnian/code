    private static bool IsValidRegex(string input)
    { 
       try
       {
         Regex.Match("", input);
       }
       catch (ArgumentException)
       {
          return false;
       }
  
      return true;
    }
