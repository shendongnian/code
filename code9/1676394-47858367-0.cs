    public interface ILocalisationService
    {
        string CurrencySymbol { get; }
    }
    public class LocalisationService : ILocalisationService
    {
        private IConfigurationService _configurationService;
        private string _currencySymbol;
        public LocalisationService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        public string CurrencySymbol => string.IsNullOrEmpty(_currencySymbol)
            ? _currencySymbol = _configurationService.GetValue("£")
            : _currencySymbol;
    }
