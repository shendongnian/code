    private int GetMultiplesOfTenUpTo(int upTo)
    {
        int remainder = upTo % 10;
        if(remainder < 5)
        {
            return upTo / 10; // is rounded to the next lower multiple of 10
        }
        else 
        {
            return upTo / 10 + 10; //  to the next higher multiple of ten
        }
    }
    private int GetClosestValue(IEnumerable<int> input, int targetValue)
    {
        return input.Select(i => new{Value = i, Distance = i-targetValue})
            .OrderBy(x => Math.Abs(x.Distance))
            .First().Value;
    }
