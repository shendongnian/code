    interface ICurrencyProvider {
        //...members
    }
    public interface ICurrencyProviderStrategy {
        string Name { get; }
        ICurrencyProvider Create();
    }
    public interface ICurrencyProviderFactory {
        ICurrencyProvider GetCurrencyServiceProvider(string providerName);
    }
