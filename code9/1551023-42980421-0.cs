    public static object MatchAccountType<T>(string acctTypeStr)
    {
        var acctTypes = SharedUtils.GetEnumValues<T>();
        foreach (T acctType in acctTypes)
        {
            if (acctTypeStr.ToUpper() == acctType.ToString().ToUpper())
            {
                return acctType;
            }
        }
        return null;
    }
