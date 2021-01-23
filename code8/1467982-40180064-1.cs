    public class Person : IValidatableObject 
     { 
        public int Id { get; set; }
    
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        public Address HomeAddress { get; set; }
    
        public Address WorkAddress { get; set; }
     
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        { 
            if (HomeAddress == null && WorkAddress == null) 
            { 
                yield return new ValidationResult 
                  ("At least one between the home and work address must be set", new[] { "HomeAddress", "WorkAddress" }); 
             } 
        } 
    }
