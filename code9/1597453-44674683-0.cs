    string userFormat = @"hh;mm;;ss+++ffff*h"; // is this allowed?
    // Gini pig
    TimeSpan sample = new TimeSpan(1234567);
  
    string escaped = string.Concat(userFormat
      .Select(c => char.IsLetter(c) 
        ? c.ToString() 
        : "\\" + c.ToString())); // deilimters like :,;+... should be escaped
    try {
      sample.ToString(escaped);
      // userFormat is OK 
    }
    catch (FormatException) {
      // userFormat is not a correct one 
    } 
