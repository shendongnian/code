    public class CultureInfoWrapper
    {
        private readonly CultureInfo _cultureInfo;
        public CultureInfo Value
        {
            get { return _cultureInfo; }
        }
        public CultureInfoWrapper(string cultureName, string fallbackCultureName = "en-US")
        {
            try
            {
                _cultureInfo = new CultureInfo(cultureName);
            }
            catch (CultureNotFoundException)
            {
                _cultureInfo = new CultureInfo(fallbackCultureName);
            }
        }
    }
