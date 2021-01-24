    public class RequiredNumberAttribute : ValidationAttribute, IClientModelValidator
    {
        private int[] allowedNumbers;
        public RequiredNumberAttribute(params int[] numbers)
        {
             allowedNumbers = numbers;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int number = (int)validationContext.ObjectInstance;
            if (allowedNumbers.Contains(number))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Error: Number must be 7,30,60");
        }
