    public class ValidationResult
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
    public interface IValidator<T>
    {
        IEnumerable<ValidationResult> IsValid(T model);
    }
    
    //...in your implementation
    public IEnumerable<ValidationResult> IsValid(User user)
    {
        //Return a new ValidationResult per validation error
        if (_context.Users.Any(c => c.EmailAddress == user.EmailAddress))
        {
            yield return new ValidationResult
            {
                Message = "Email address already in use",
                FieldName = nameof(user.EmailAddress)
            };
        }
    }
