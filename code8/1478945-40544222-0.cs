    public class Sample : IValidatableObject
    {
        public DateTime Date { set; get; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date > new DateTime(2012, 12, 12))
            {
                yield return new ValidationResult("you cant enter it");
            }
        }
    }
