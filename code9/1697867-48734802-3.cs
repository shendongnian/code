    public class Cost
    {
        public Cost(Money amount)
        {
            if(amount.Currency != Currency.GBP)
                throw new ArgumentException("The currency type must be GPB.");
            var rounded = Money.Round(amount, 2);
            if(rounded.Amount <= 0m)
                throw new ArgumentOutOfRangeException(nameof(amount), $"{nameof(amount)} must be greater than zero when rounded to two decimal places.");
            Amount = rounded;
        }
        
        public Money Amount { get; }
    }
