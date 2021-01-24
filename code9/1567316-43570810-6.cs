    [AttributeUsage(AttributeTargets.Class)]
    public class AggregatedRequiredAttribute: ValidationAttribute
    {
        private readonly string[] _propertiesToValidate;
        private readonly string message = Resources.ValRequired;
        public AggregatedRequiredAttribute(params string[] propertiesToValidate)
        {
            if (propertiesToValidate == null || !propertiesToValidate.Any()) throw new ArgumentException(nameof(propertiesToValidate));
            _propertiesToValidate = propertiesToValidate;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!validationContext.ObjectType.GetMember(validationContext.MemberName).Any())
                throw new InvalidOperationException("Current type does not contain such property.");
            if (!_propertiesToValidate.Contains(validationContext.MemberName))
                return ValidationResult.Success;
            var defaultRequired = new RequiredAttribute() {ErrorMessage = message};
            return defaultRequired.IsValid(value) ? ValidationResult.Success : new ValidationResult(message);
        }
    }
