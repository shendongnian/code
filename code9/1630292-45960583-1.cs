    public static bool IsEmail(string emailToValidate)
    {
        if (string.IsNullOrEmpty(emailToValidate)) return true;
        return Regex.IsMatch(emailToValidate, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
