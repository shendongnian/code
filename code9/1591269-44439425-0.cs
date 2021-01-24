    public static bool numValidation(string strNum)
    {
        Regex regex = new Regex(@"^[0-9]+$");
        return (regex.IsMatch(strNum)) ;
    }
