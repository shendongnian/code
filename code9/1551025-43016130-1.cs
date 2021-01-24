     public class DynamicItemViewModel : IValidatableObject
    {
        ...
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Items.SelectMany(x => x.Validate(validationContext));
        }
    }
