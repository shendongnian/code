        public class OnlyOneValueAttribute : ValidationAttribute
        {
            public string TheOtherPropertyName { get; private set; }
    
            public OnlyOneValueAttribute(string theOtherPropertyName)
            {
                TheOtherPropertyName = theOtherPropertyName;
            }
    
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var theProperty = validationContext.ObjectType.GetProperty(validationContext.MemberName);
                var theValue = theProperty.GetValue(validationContext.ObjectInstance, null) as string;
    
                var theOtherProperty = validationContext.ObjectType.GetProperty(TheOtherPropertyName);
                var theOtherValue = theOtherProperty.GetValue(validationContext.ObjectInstance, null) as string;
                
                if (string.IsNullOrEmpty(theValue) && !string.IsNullOrEmpty(theOtherValue) || !string.IsNullOrEmpty(theValue) && string.IsNullOrEmpty(theOtherValue))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }
        }
