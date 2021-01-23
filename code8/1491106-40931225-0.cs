      public static string Reverse(string s) {
        if (string.IsNullOrEmpty(s)) // public method wants validation
          return s; // or throw exception
 
        return string.Concat(s
          .Where(char.IsLetter)
          .Concat(s.Where(char.IsDigit)));
      }
