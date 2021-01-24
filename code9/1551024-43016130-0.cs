    public class EntityAttributeProperties : IValidatableObject
    {
        public string Name { get; set; }
    
        [Required]
        public object Value { get; set; }
    
        ...
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (... /* some condition, e.g. specific EntityAttributeDataTypeEnum */)
            {
                // Do some validation
    
                // some other random test
                if (.../* something not right... */)
                {
                    results.Add(new ValidationResult("your input was not valid!"));
                }
            }
            return results;
        }
    }
