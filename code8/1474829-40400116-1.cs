    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    class ModelValidator
    {
        public static IEnumerable<ValidationResult> Validate<T>(T model) where T : class, new()
        {
            model = model ?? new T();
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
