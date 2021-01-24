    public ValidationResult IsValid(User user)
    {
      ValidationResult validationResult = new ValidationResult(true, "");
      if (_context.Users.Any(c => c.EmailAddress == user.EmailAddress))
      {
        validationResult.Status = false;
        validationResult.Message = "Email address already in use";
        return validationResult;
      }
    
      return validationResult;
    }
