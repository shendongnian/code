    public class RequiredIfUniTestIsYes : ValidationAttribute, IClientValidatable
    {
        private string _dependency;
        public RequiredIfUniTestIsYes(string dependency)
        {
            _dependency = dependency;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var countryPropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(_dependency);
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
