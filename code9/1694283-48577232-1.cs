    using System.Text.RegularExpressions;
    ...
    string test = "1,2,3";
    if (Regex.IsMatch(test, @"^[0-9a-zA-Z](,[0-9a-zA-Z])*$")) {
      // Matched
    }
