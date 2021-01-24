    private static readonly Dictionary<int, int> MyIndexes = new Dictionary<int, int>();
    public static char NextCharacter(int index, string input)
    {
        if (!MyIndexes.ContainsKey(index)) MyIndexes[index] = 0;
        return input[MyIndexes[index]++];
    }
