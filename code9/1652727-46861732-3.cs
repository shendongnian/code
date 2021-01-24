    public static List<AmountRange> GetAmountRange(int[] terms)
    {
         return amountTable
            .Select(x => new {Item=x, Terms=terms.Where(z => z.IsBetween(x.MinTerm, x.MaxTerm)})
            .SelectMany(x => x.Terms.Select(term => new AmountRange(term, x.Item.MinAmount, x.Item.MaxAmount))
            .ToList();
    }
