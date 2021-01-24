    public class ValidationResult
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
    
    //In your interface
    public IEnumerable<ValidationResult> IsValid(User user)
    {
        //Return a new ValidationResult per validation error
    }
