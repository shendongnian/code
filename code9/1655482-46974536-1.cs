    public static bool IsValidPattern(string str)
      {
         return !Regex.IsMatch(str, @"((?<!\+)[a-zA-Z])|([a-zA-Z]+(?!\+))");
      }
    
