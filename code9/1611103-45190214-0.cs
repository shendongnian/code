    #region Performance Test
    private const int Iterations = 500;
    private const int NumStrings = 250000;
    private const int TestStringLength = 50;
    private static string EmptyLine;
    public static string PadRight(string input)
    {
        return input.PadRight(TestStringLength, ' ');
    }
    public static string PadRight2(string input)
    {
        return input + EmptyLine.Substring(0, TestStringLength - input.Length);
    }
    #endregion // Performance Test
