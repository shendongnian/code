    private static readonly Dictionary<string, int> MyStrings = new Dictionary<string, int>();
    public static char NextCharacter(string input)
    {
        if (!MyStrings.ContainsKey(input)) MyStrings[input] = 0;
        return input[MyStrings[input]++];
    }
