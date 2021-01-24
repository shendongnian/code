    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class ValidDecimal : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (value == null || value.ToString().Length == 0) {
                return ValidationResult.Success;
            }
            decimal d;
            return !decimal.TryParse(value.ToString(), out d) ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }
    }
