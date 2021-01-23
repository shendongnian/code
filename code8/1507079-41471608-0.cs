    private static string letterFunc (string validate)
    {
        return new Regex("^[A-Z]+$").IsMatch(validate) ? 
               validate :
               string.Empty;
    }
