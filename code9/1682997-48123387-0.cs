    public class PostalCodeValidator
    {
        private readonly IPostalCodeRegexProvider _regexProvider;
        public PostalCodeValidator(IPostalCodeRegexProvider regexProvider)
        {
            _regexProvider = regexProvider;
        }
        public bool ValidatePostalCode(string postalCode, string countryCode)
        {
            var regex = _regexProvider.GetPostalCodeRegex(countryCode);
            if (string.IsNullOrEmpty(regex)) return true;
            return Regex.IsMatch(postalCode, regex);
        }
    }
    public interface IPostalCodeRegexProvider
    {
        string GetPostalCodeRegex(string countryCode);
    }
