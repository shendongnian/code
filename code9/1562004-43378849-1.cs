    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double v = 0.0;
            if(double.TryParse(value as string, out v))
            {
                if(v <= 0.0)
                {
                    return new ValidationResult(false, "number must be greater than 0");
                }
            }
            else
            {
                return new ValidationResult(false, "entered value is not a number");
            }
            return new ValidationResult(true, null);
        }
    }
 
