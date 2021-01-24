    public static string CleanPlocPloc(string message)
    {
        message = Regex.Replace(message, "^!.+?!", "");
        message = Regex.Replace(message, @"\.(\s(Ploc|Plo))*\s!$", ".");
        return message;
    }
