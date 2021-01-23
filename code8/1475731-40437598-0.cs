    public interface IAccoutServiceFactory
    {
        IAccountService Create(List<ValidationResult> validationResults);
    }
    // in controller
    List<ValidationResult> validationResults = ConvertToValidationResults(ModelState);
    IAccountService accountService = accountServiceFactory.Create(
