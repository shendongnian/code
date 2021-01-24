    public class AmountRange
    {
        public AmountRange(int term, int minAmount, int maxAmount)
        {
            Term = term;
            MinTerm = minAmount;
            MaxTerm = maxAmount;
        }
        public int Term { get; }
        public int MinTerm { get; }
        public int MaxTerm { get; }
    }
