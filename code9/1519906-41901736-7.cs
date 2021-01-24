    public class MyViewModel
    {
        [DateLessThan("End", ErrorMessage = "Not valid")]
        public DateTime Begin { get; set; }
    
        public DateTime End { get; set; }
    }
    public class DateLessThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
    
        public DateLessThanAttribute(string comparisonProperty)
        {
             _comparisonProperty = comparisonProperty;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;
    
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            
            if (property == null)
                throw new ArgumentException("Property with this name not found");
    
            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);
    
            if (currentValue > comparisonValue)
                return new ValidationResult(ErrorMessage);
               
            return ValidationResult.Success;
        }
    }
