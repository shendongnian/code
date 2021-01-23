    [AttributeUsage(AttributeTargets.Property)]
    public class DoubleGreaterThanAttribute : ValidationAttribute
    {
        public DoubleGreaterThanAttribute(string doubleToCompareToFieldName)
        {
            DoubleToCompareToFieldName = doubleToCompareToFieldName;
        }
        private string DoubleToCompareToFieldName { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double west = (double)value;
            double east = (double)validationContext.ObjectType.GetProperty(DoubleToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);
            if (east > west)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("West cannot be bigger than east coordinate.");
            }
        }
    }
