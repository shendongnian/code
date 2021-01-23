      [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        public class NumberGreaterThanAttribute : ValidationAttribute, IClientValidatable
        {
            string otherPropertyName;
    
    
            public NumberGreaterThanAttribute(string otherPropertyName, string errorMessage)
                : base(errorMessage)
            {
                this.otherPropertyName = otherPropertyName;
            }
    
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                ValidationResult validationResult = ValidationResult.Success;
    
    
                if (value == null)
                    return validationResult;
    
                try
                {
                    // Using reflection we can get a reference to the other date property, in this example the project start date
                    var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                    object referenceProperty = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                    
                    if (referenceProperty == null)
                        return validationResult;
    
                    double referenceProperty_value = System.Convert.ToDouble(referenceProperty, null);
                    double currentField_value = System.Convert.ToDouble(value, null);
    
    
                    if (currentField_value <= referenceProperty_value)
                    {
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
    
                }
                catch (Exception ex)
                {
    
                    throw ex;
                }
    
    
                return validationResult;
            }
    
    
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                //string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
                string errorMessage = ErrorMessageString;
    
                // The value we set here are needed by the jQuery adapter
                ModelClientValidationRule numberGreaterThanRule = new ModelClientValidationRule();
                numberGreaterThanRule.ErrorMessage = errorMessage;
                numberGreaterThanRule.ValidationType = "numbergreaterthan"; // This is the name the jQuery adapter will use
                //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
                numberGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);
    
                yield return numberGreaterThanRule;
            }
        }
