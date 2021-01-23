    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RequiredWithAttribute : ValidationAttribute, IClientValidatable
    {
        private const string _DefaultErrorMessage = "The {0} is also required.";
        private readonly string _OtherPropertyName;
        public RequiredWithAttribute(string otherPropertyName)
        {
            if (string.IsNullOrEmpty(otherPropertyName))
            {
                throw new ArgumentNullException("otherPropertyName");
            }
            _OtherPropertyName = otherPropertyName;
            ErrorMessage = _DefaultErrorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(_OtherPropertyName);
                var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);
                if (otherPropertyValue == null)
                {
                    return new ValidationResult(string.Format(ErrorMessageString, _OtherPropertyName));
                }
            }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(_OtherPropertyName),
                ValidationType = "requiredwith",
            };
            rule.ValidationParameters.Add("dependentproperty", _OtherPropertyName);
            yield return rule;
        }
    }
