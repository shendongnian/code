    public struct Money : IComparable<Money>, IComparable, IXmlSerializable
    {
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }
        public static Money Round(Money m)
        {
            return new Money(decimal.Round(m.Amount), m.Currency);
        }
    }
