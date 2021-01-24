    public class RequiredNumberAttribute : ValidationAttribute, IClientModelValidator
    {
        private int[] allowedNumbers;
        public RequiredNumberAttribute(params int[] numbers)
        {
             allowedNumbers = numbers;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int number = (int)value;
            if (allowedNumbers.Contains(number))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Error: Number must be {string.Join(",", allowedNumbers)}");
        }
