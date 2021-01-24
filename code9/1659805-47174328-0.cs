    private decimal CleanUserInput(string userInput, CultureInfo LocaleUser)
    {
        if (LocaleUser == null)
        throw new Exception("A CultureInfo must be specified. ");
    
        var cleanedInput = Regex.Replace(userInput, @"[^0-9-,\.']+", "");
        if (string.IsNullOrWhiteSpace(cleanedInput))
            throw new Exception("Data provided has no numbers to be parsed. ");
    
        decimal numericData;
        if (!decimal.TryParse(cleanedInput, NumberStyles.Any, LocaleUser, out numericData))
            throw new Exception($"Couldn't parse {cleanedInput} . Make sure the applied CultureInfo ({LocaleUser.DisplayName}) is the correct one. Decimal separator to be applied: <{LocaleUser.NumberFormat.NumberDecimalSeparator}> Numeric group separator to be applied: <{LocaleUser.NumberFormat.NumberGroupSeparator}>");
    
        return numericData;
    }
