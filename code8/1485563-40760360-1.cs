    public class RequiredIfUniTestIsYes : ValidationAttribute, IClientValidatable
    {
        private string _dependancy;
        public RequiredIfUniTestIsYes(string dependancy)
        {
            _dependancy = dependancy;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var countryPropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(_dependancy);
            var countryValue = (bool)countryPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            var number = default(long);
            if (countryValue && (value == null || !long.TryParse(value.ToString(), out number)))
            {
                return new ValidationResult("Please Enter Unit Test Job Order Number");
            }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = "Please Enter Unit Test Job Order Number";
            rule.ValidationParameters.Add("istestunit", "true");
            rule.ValidationType = "isunittest";
            yield return rule;
        }
    }
