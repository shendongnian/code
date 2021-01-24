    void FindAlternativeSequences()
    {
        var observations = new List<int>() { 1, 3, 4, 2, 7, 5, 6, 8, 1, 2, 4 };
        const int threshold = 4;
    
        var consecutivePairs = observations.Skip(1).Zip(observations, (a, b) => Math.Sign(a - b)).Zip(GetAlternator(), (x, y) => x * y);
        var runs = FindEqualRuns(consecutivePairs).Select(t => new Tuple<int, int>(t.Item1, t.Item2 + 1)).ToList();
    }
    
    public IEnumerable<int> GetAlternator()
    {
        int value = -1;
        int sanity = Int32.MaxValue;
        while (--sanity > 0)
        {
            value *= -1;
            yield return value;
        }
        yield break;
    }
    
    public IEnumerable<Tuple<int,int>> FindEqualRuns(IEnumerable<int> enumerable)
    {
        int previousValue = 0;
        int index = 0;
        int startIndex = 0;
        
        foreach ( var value in enumerable )
        {
            if (index == 0) previousValue = value;
            
            if (!value.Equals(previousValue))
            {
                // This is a difference, return the previous run
                yield return new Tuple<int, int>(startIndex, index - startIndex);
                startIndex = index;
                previousValue = value;
            }
            
            index++;
        }
        
        yield break;
    }
