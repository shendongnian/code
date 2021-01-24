    string filter = "rafa va";
    // We assume that 
    //   1. Patterns are separated by space (or tabulation)
    //   2. Patterns should be matched in any order 
    //   3. Case should be ignored 
    var patterns = filter
      .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
      .Select(item => Regex.Escape(item)) // <- comment it out if you want to allow, say, \d+ 
      .ToArray();
    var result = _userList
      .Where(user => patterns
         .All(pattern => Regex.IsMatch(user.ToString(), pattern, RegexOptions.IgnoreCase)));
