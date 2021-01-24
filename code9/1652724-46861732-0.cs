    public static AmountRange GetAmountRange(int[] terms)
    {
         return amountTable
            .Where(x => terms.All(y => y.IsBetween(x.MinTerm, x.MaxTerm)))
            .Select(x => new AmountRange(terms, x.MinAmount, x.MaxAmount))
            .First();
    }
