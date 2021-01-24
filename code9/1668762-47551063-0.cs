    public class DateTimeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            TimeSpan reded;
            if(!TimeSpan.TryParseExact(value.ToString(), "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out reded))
                return new ValidationResult(false, "Invalid time!");
            return ValidationResult.ValidResult;
        }
    }
