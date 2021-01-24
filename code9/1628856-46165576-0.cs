    public static class DecimalExtensions
    {
        private static readonly IDictionary<String, String> _currencyCodeToSymbol = new Dictionary<String, String>
        {
            { "EUR", "€"},
            { "USD", "$"},
            { "GBP", "£"},
        };
        private static readonly ConcurrentDictionary<String, CultureInfo> _currencyCodeToLocale =
            new ConcurrentDictionary<String, CultureInfo>();
        public static String FormatCurrency(this Decimal decimalValue, String currencyCode = "USD")
        {
            if (!_currencyCodeToSymbol.ContainsKey(currencyCode))
            {
                throw new NotImplementedException($"Currency code {currencyCode} is not supported");
            }
            var cultureInfo = _currencyCodeToLocale.GetOrAdd(currencyCode, _ =>
            {
                var info = CultureInfo.CurrentCulture.Clone() as CultureInfo;
                info.NumberFormat.CurrencySymbol = _currencyCodeToSymbol[currencyCode];
                return info;
            });
            return decimalValue.ToString("C", cultureInfo);
        }
    }
