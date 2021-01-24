    public static int CountZerosBetweenOnes(int binary)
    {
        var indicesOfOnes = 
            Convert.ToString(binary, 2)
            .Select((c, i) => new {c, i})
            .Where(x => x.c == '1')
            .Select(x => x.i);
        return 
            indicesOfOnes
            .Zip(indicesOfOnes.Skip(1), (a, b) => b - a - 1)
            .DefaultIfEmpty(0)
            .Max();
    }
