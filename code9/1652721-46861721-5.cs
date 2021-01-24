    public static Dictionary<int, AmountRange> GetAmountRanges(int[] terms)
    {
         return terms.Distinct().ToDictionary(
                     key => key,  
                     term => amountTable
                     .Where(x => term.IsBetween(x.MinTerm, x.MaxTerm))
                     .Select(x => new AmountRange(term, x.MinAmount, x.MaxAmount))
                     .First());
    }
