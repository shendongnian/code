    public class StringLengthRule : ValidationRule
    {
        public int MaxLength { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (((string)value).Length > MaxLength)
                return new ValidationResult(false, "Input too long!");
            return new ValidationResult(true, null);
        }
    }
