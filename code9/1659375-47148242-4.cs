    public class CurrencyLayerWrapperProvider : ICurrencyProviderStrategy {
        public string Name { get { return "CurrencyLayerAPI"; } }
        public ICurrencyProvider Create() {
            return new CurrencyLayerWrapper();
        }
    }
