    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class CountryCodeAttribute : RegularExpressionAttribute
    {
        public CountryCodeAttribute() :
            base("^[A-z]{2,3}([-]{1}[A-z]{2,})?([-]?[A-z]{2})?$")
        {
            ErrorMessage = "Invalid country code.";
        }
    }
