    public static bool HasBase(int b, int n)
    {
        // find all factors of b
        var factors = new List<int>();
        var dividers = Enumerable.Range(2, (int)Math.Round(Math.Sqrt(b) + 1)).GetEnumerator();
        dividers.MoveNext();
        while (true)
        {
            if (b % dividers.Current != 0)
            {
                if (dividers.MoveNext())
                    continue;
                else
                    break;
            }
            
            b /= dividers.Current;
            factors.Add(dividers.Current);
        }
        
        // if the base of each power can be divided by 3, a^n=b should be true.
        return multiples
            .GroupBy(x => x)
            .All(g => g.Count() % 3 == 0)
    }
