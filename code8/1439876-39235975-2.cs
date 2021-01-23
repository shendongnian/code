    public static bool AreAllNumbersGenerated2(int[] row)
    {
        var available = row.ToDictionary(x => x);
        return Enumerable.Range(0, row.Length).All(i => available.ContainsKey(i));
    }
