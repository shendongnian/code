    // This pattern enforces our rule that a pwd must have one letter and one digit.
    string pattern = @" # This regex pattern enforces the rules before returning matching
    (?=.*[a - zA - Z])  # Somewhere there is a an alphabectic character
    (?=.*\d)            # Somewhere there is a number; if no number found return no match.
    (.+)                # Successful match, rules are satisfied. Return match";
    
    Random rn = new Random(); // Used to cherry pick from chars to use.
    // Creates 48 alpha and non alpha (at least 10 non digit alphas) random characters.
    string charsToUse = System.Web.Security.Membership.GeneratePassword(48, 5);
    
    // When replacement is done, replace an `X` matched with a random char. 
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
