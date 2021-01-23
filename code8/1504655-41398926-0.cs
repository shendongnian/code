    [Intercept(typeof(CallLogger))]
    public interface IPortfolio
    {
        decimal Value { get; }
        void Add(string symbol, uint holding);
    }
