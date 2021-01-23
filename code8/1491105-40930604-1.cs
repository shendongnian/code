    public static string Reverse (string s)
    {
        char[] digits = s.Where(c => Char.IsDigit(c)).ToArray();
        char[] letters = s.Where(c => !Char.IsDigit(c)).ToArray();
        return new string(letters) + new string(digits);
    }
