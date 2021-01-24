    public partial class Zone
    {
        [RequireCondition(1)]
        public int LastCount { get; set; }
    }
    
    public class RequireConditionAttribute : ValidationAttribute
     {
         private int _comparisonValue;
    
         public RequireCondition(int comparisonValue)
         {
            _comparisonValue = comparisonValue;
         }
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
          {              
            if (value is int && (int)value < comparisonValue)
                {
                  return new ValidationResult($"{validationContext.DisplayName} value must be greater than one.");
                }
    
                return ValidationResult.Success;
            }
        }
