    public class RequiredDecimalRule : ValidationRule
    {
        public RequiredDecimalRule()
        {
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal d;
            if (value == null || !Decimal.TryParse(value.ToString(), out d))
            {
                return new ValidationResult(false, "Numeric value is required");
            }
            return new ValidationResult(true, null);
        }
    }
