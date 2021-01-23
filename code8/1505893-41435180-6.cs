    private bool IsBetweenDates(string value)
    { 
        var dateValue = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        return dateValue >= fromDate.Value && dateValue <= toDate.Value;
    }
    private string[] Split(string line)
    {
        if (string.IsNullOrWhitespace(x))
        {
            // There is nothing in this line. Is this allowed in your case?
            // If yes do whatever you need to do here. For example, log it or something.
        }
        var splits = line.Split((char)9);
        if (splits.Length != 6)
        {
            // This line does not have 6 fields so what do you want to do?
        }
    
        return splits;
    }
