    string pattern = @"
    (?=.*[a - zA - Z])  # Somewhere there is a an alphabectic character
    (?=.*\d)            # Somewhere there is a number
    (.+)                # Successful match, rules are satisfied.";
    
    Random rn = new Random();
    string charsToUse = System.Web.Security.Membership.GeneratePassword(48, 5);
    
    MatchEvaluator RandomChar = delegate (Match m)
    {
        return charsToUse[rn.Next(charsToUse.Length)].ToString();
    };
    
    Func<string, string> Validate = 
          (string str) => Regex.IsMatch(str, pattern, RegexOptions.IgnorePatternWhitespace) 
                          ? str : string.Empty; // return empty on failure.
    
    string pwdClear = string.Empty;
    
    // Generate valid pwd based on rules. Loop until rules are met.
    while (string.IsNullOrEmpty(pwdClear))
        pwdClear = Validate(Regex.Replace("XXXX-XXXX-XXXX-XXXX-XXXX", "X", RandomChar));
    
    // Create a secure string for the password for transportation.
    SecureString ss = new SecureString();
    
    pwdClear.ToList()
            .ForEach(chr => ss.AppendChar(chr));
