    public class ValuesLength : StringLengthAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = true;
            var pair = value as TextPair;
            if (pair != null && pair.Value != null)
            {
                var pairValue = pair.Value;
                isValid = pairValue.Length < MaximumLength && pairValue.Length > MinimumLength;
            }        
    
            return IsValid ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
