    public static bool emailIsValid(string email)
    {
        string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expression))
        {
            return Regex.Replace(email, expression, string.Empty).Length == 0;
        }
        else
        {
            return false;
        }
    }
