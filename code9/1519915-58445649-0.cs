    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ComparisonAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        private readonly ComparisonType _comparisonType;
        public ComparisonAttribute(string comparisonProperty, ComparisonType comparisonType)
        {
            _comparisonProperty = comparisonProperty;
            _comparisonType = comparisonType;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                throw new ArgumentException($"Property {_comparisonProperty} not found");
            var right = property.GetValue(validationContext.ObjectInstance);
            if (value is null || right is null)
                return ValidationResult.Success;
            if (value.GetType() == typeof(IComparable))
                throw new ArgumentException($"The property {validationContext.MemberName} does not implement {typeof(IComparable).Name} interface");
            if (right.GetType() == typeof(IComparable))
                throw new ArgumentException($"The property {_comparisonProperty} does not implement {typeof(IComparable).Name} interface");
            if (!ReferenceEquals(value.GetType(), right.GetType()))
                throw new ArgumentException("The property types must be the same");
            var left = (IComparable)value;
            bool isValid;
            switch (_comparisonType)
            {
                case ComparisonType.LessThan:
                    isValid = left.CompareTo((IComparable)right) < 0;
                    break;
                case ComparisonType.LessThanOrEqualTo:
                    isValid = left.CompareTo((IComparable)right) <= 0;
                    break;
                case ComparisonType.EqualTo:
                    isValid = left.CompareTo((IComparable)right) != 0;
                    break;
                case ComparisonType.GreaterThan:
                    isValid = left.CompareTo((IComparable)right) > 0;
                    break;
                case ComparisonType.GreaterThanOrEqualTo:
                    isValid = left.CompareTo((IComparable)right) >= 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return isValid
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }
        public enum ComparisonType
        {
            LessThan,
            LessThanOrEqualTo,
            EqualTo,
            GreaterThan,
            GreaterThanOrEqualTo
        }
    }
