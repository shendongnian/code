    public class Cost
    {
        public Cost(decimal amount)
        {
            var rounded = decimal.Round(amount, 2);
            if(rounded <= 0m)
                throw new ArgumentOutOfRangeException(nameof(amount), $"{nameof(amount)} must be greater than zero when rounded to two decimal places.");
            Amount = rounded;
        }
        
        public decimal Amount { get; }
    }
