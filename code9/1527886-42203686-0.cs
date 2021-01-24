    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FrenchEmailAddressAttribute : ValidationAttribute
    {
        public string Pattern { get; set; }
        public RegexOptions Options { get; set; }
    
        public FrenchEmailAddressAttribute(string pattern, RegexOptions options = RegexOptions.None)
        {
            Pattern = pattern;
            Options = options;
        }
    
        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }
    
        public bool IsValid(string value)
        {
            return string.IsNullOrEmpty(value) ? true : new Regex(Pattern, Options).IsMatch(value);
        }
    }
