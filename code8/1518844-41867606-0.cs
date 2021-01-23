    namespace System.Linq //Using System.Linq namespace makes it easier to use
    {
        public static class MoneyEnumerable
        {
            public static Money Sum(this IEnumerable<Money> monies)
            {
                return monies.Aggregate((left, right) => left + right);
            }
        }
    }
