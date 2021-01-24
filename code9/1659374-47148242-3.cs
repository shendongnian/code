    public class CurrencyProviderFactory : ICurrencyProviderFactory {
        private readonly IEnumerable<ICurrencyProviderStrategy> strategies;
        public CurrencyProviderFactory(IEnumerable<ICurrencyProviderStrategy> strategies) {
            this.strategies = strategies;
        }
        public ICurrencyProvider GetCurrencyServiceProvider(string providerName) {
            var provider = strategies.FirstOrDefault(p => p.Name == providerName);
            if (provider != null)
                return provider.Create();
            return null;
        }
    }
