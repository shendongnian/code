    public sealed class ByteCountValidationRule : ValidationRule
    {
        // For this example I test using an emoji () which will take 2 bytes and fail this rule.
        static readonly int MaxByteCount = 1;
        static readonly ValidationResult ByteCountExceededResult = new ValidationResult(false, $"Byte count exceeds the maximum allowed limit of {MaxByteCount}");
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var val = value as string;
            return val != null && Encoding.UTF8.GetByteCount(val) > MaxByteCount
                ? ByteCountExceededResult
                : ValidationResult.ValidResult;
        }
    }
