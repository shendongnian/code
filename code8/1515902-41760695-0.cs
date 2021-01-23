    public static bool CheckSpecialCharacter(string value, out string character)
    {
        var regex = new System.Text.RegularExpressions.Regex(@"[~`!@#$%^*()=|\{}';.,<>]");
        var match = regex.Match(value);
        character = regex.Match(value).Value;
        return match.Length == 0;
    }
