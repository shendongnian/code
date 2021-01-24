    public class SpaceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if(str == null)
            {
                return new ValidationResult(false, "Please enter some text");
            }
            if(!str.Contains(" "))
            {
                return new ValidationResult(false, "Contains Spaces!);
            }
            return new ValidationResult(true, null); 
        }
    }
