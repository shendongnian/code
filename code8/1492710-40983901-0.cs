    private static readonly DateTime minDB_smallDateTime = new DateTime(1900,1,1);
    private static bool IsBasicallyNull(string input)
    {
        if (String.IsNullOrWhiteSpace(input))
            return true;
        DateTime output;
        var isValidDateTime = DateTime.TryParse(input, out output);
        if (isValidDateTime && output <= minDB_smallDateTime)
           return true;
        .... rest of checking code....
    }
