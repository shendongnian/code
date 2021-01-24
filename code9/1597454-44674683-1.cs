    private static bool IsValidFormat(string userFormat) {
      // Gini pig
      TimeSpan sample = new TimeSpan(1234567);
  
      string escaped = string.Concat(userFormat
        .Select(c => char.IsLetter(c) 
           ? c.ToString() 
           : "\\" + c.ToString())); // deilimters like :,;+... should be escaped
      try {
        sample.ToString(escaped);
         
        return true;
      }
      catch (FormatException) {
        return false; 
      } 
    }
    ...
    // is this allowed? - true
    Console.WriteLine(IsValidFormat(@"hh;mm;;ss+++ffff*h"));
    // is this allowed? - false
    Console.WriteLine(IsValidFormat(@"zzzz"));
   
