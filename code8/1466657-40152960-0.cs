    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class EmailAddressListAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "{0} contains invalid email addresses.";
        private const string RegexPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*" +
                                            @"@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        public EmailAddressListAttribute()
          : base(DefaultErrorMessage)
        {
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = $"{validationContext.DisplayName} contains invalid email addresses";
            if (value.ToString().IsNullOrWhiteSpace()) return null;
            var emailList = value.ToString().Split(';');
            return emailList.Where(e => !IsValidEmail(e))
                .ToList()
                .Count == 0 ? null : new ValidationResult(ErrorMessage);
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "emailaddresslist"
            };
            clientValidationRule.ValidationParameters.Add("otherproperty", "");
            return new[] { clientValidationRule };
        }
        private static bool IsValidEmail(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, RegexPattern, RegexOptions.IgnoreCase);
        }
    }
