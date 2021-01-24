    public static String FilePassword()
    {
        string retString = string.Empty;
        while (retString.Length < 12)
        {
            retString += string.Concat(Membership.GeneratePassword(1, 0).Where(char.IsLetterOrDigit));
        }    
        return retString;
    }
