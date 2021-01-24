    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class LessThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public LessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            if (value.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("value has not implemented IComparable interface");
            }
            var currentValue = (IComparable)value;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
            {
                throw new ArgumentException("Comparison property with this name not found");
            }
            var comparisonValue = property.GetValue(validationContext.ObjectInstance);
            if (comparisonValue.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("Comparison property has not implemented IComparable interface");
            }
            if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
            {
                throw new ArgumentException("The properties types must be the same");
            }
            if (currentValue.CompareTo((IComparable)comparisonValue) >= 0)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
