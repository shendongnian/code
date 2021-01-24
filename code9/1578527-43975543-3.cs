    public static string PadNumbers(string input)
    {
        // replace number "2" into number of digits you want to group with
        return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(2, '0'));
    }
