    public class Arbitraries
    {
        public static Arbitrary<DiscountAmount> DiscountAmounts()
        {
            var toReturn = (from a in Amounts().Generator
                            select new DiscountAmount(a))
                          .ToArbitrary();
            return toReturn;
        }
    
        public static Arbitrary<Amount> Amounts()
        {
            return Arb.Generate<decimal>().Where(x => x > 0)
                .Select(x => new Amount(x))
                .ToArbitrary();
        }
    } 
