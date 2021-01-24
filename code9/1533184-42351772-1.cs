    static readonly char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static string TrimNonNumbers(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;//Our math will produce an index out of range exception with an empty string.  So this is a safety to prevent that.
        return numbers.Any(x => x == testInput[testInput.Length - 1]) ? testInput : testInput.SubString(0, testInput.Length - 1);
    }
