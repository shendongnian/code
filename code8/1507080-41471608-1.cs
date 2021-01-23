    private static string letterFunc (string validate)
    {
        return new Regex("^[A-Z][a-z]*+$").IsMatch(validate) ? 
               validate :
               string.Empty;
    }
