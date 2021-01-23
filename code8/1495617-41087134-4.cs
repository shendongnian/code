    internal static class ValidationMethods
    {
        public static bool CheckIsValid1(this IList<ValidationResult> valResults, int number, string family)
        {
            var validationResult = new validationResult();
            if(number > 10 || family="akbari")
            {
                validationResult.Errors.Add(new ValidationFailure("", "Invalid Number"));
            }
            valResults.Add(validationResult);
            return validationResult.IsValid;
        }
        public static bool CheckIsValid2(this IList<ValidationResult> valResults, string name)
        {
            // next check ...
        }
    }
