    public int GetLeadingIntegerFromString(string myString)
    {
        if (string.IsNullOrWhiteSpace(myString))
            return;
        var parts = myString.Split('-');
        if (parts.Length < 1)
            return;
        var number = int.Parse(parts[0].Trim());
        return number;
    }
