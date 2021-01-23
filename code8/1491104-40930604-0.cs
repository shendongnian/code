    public static string Reverse (string s)
    {
        char[] chars = s.ToCharArray();
        char[] digits = chars.Where(c => Char.IsDigit(c)).ToArray();
        char[] letters = chars.Where(c => !Char.IsDigit(c)).ToArray();
        return new string(letters) + new string(digits);
    }
