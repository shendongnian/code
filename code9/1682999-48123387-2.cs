    public class PostalCodeRegexProviderThatReturnsNull : IPostalCodeRegexProvider
    {
        public string GetPostalCodeRegex(string countryCode)
        {
            return null;
        }
    }
