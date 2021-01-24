        public class Book : IValidatableObject
        {
        ...
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (something != "hello")
                {
                    yield return new ValidationResult("Error message goes here");
                }
            }
