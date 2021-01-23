    public static SalesInfo Parse(string stringValue)
    {
        ...cut for brevity...
        salesInfo.Senior = ParseBool(words[3]);
        return salesInfo;
    }
    public bool ParseBool(string input)
    {
        switch (input.ToLower())
        {
            case "y":
            case "yes":
                return true;
            default:
                return false;
        }
    }
