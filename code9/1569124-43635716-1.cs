    public class Person : IValidatableObject
    {
        public PersonEmail Email {get;set;}
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Email.Home == null && Email.Work == null && Email.Other)
                results.Add(new ValidationResult("At least one email address have to be provided!"));
            return results;
        }
    }
