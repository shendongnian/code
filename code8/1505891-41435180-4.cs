    private bool IsBetweenDates(string x)
    {
        if (string.IsNullOrWhitespace(x))
        {
            // There is nothing in this line. Is this allowed in your case?
            // If yes do whatever you need to do here. For example, log it or something.
        }
        var splits = x.Split((char)9);
        if (splits.Length != 6)
        {
            // This line does not have 6 fields so what do you want to do?
        }
        if (splits.Length > 1)
        {
            var value = splits[1];
            return value >= fromDate && value <= toDate;
        }
        
    }
