    [AttributeUsage(AttributeTargets.Property]
    public class NumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.StartsWith("0"))
            {
                    return new ValidationResult(ErrorMessage, "Please enter another number!");
            }
            return ValidationResult.Success;
        }
    }
