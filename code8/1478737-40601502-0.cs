    public static bool TryMatchWithRegex(string txt, out string result)
    {
        result = string.Empty;
        // Mandatory= underscore, lowercase, uppercase
        string pattern = @"^(?=.*_)(?=.*[a-z])(?=.*[A-Z]).*$";
        Regex regex = new Regex(pattern, RegexOptions.None);
        Match match = regex.Match(txt);
        if (match.Success)
        {
            result = match.Value;
            return true;
        }
        return false;
    }
