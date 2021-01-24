    public static int CountZerosBetweenOnes(string binary)
    {
        var indicesOfOnes = 
            binary.Select((c, i) => new {c, i})
            .Where(x => x.c == '1')
            .Select(x => x.i);
        return 
            indicesOfOnes
            .Zip(indicesOfOnes.Skip(1), (a, b) => b - a - 1)
            .DefaultIfEmpty(0)
            .Max();
    }
