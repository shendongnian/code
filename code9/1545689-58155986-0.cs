csharp
public class CPFAttribute: ValidationAttribute
{
    public CPFAttribute()
    {
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string cpf;
        try
        {
            cpf = (string)value;
        }
        catch (Exception)
        {
            return new ValidationResult(GetErrorMessage(validationContext));
        }
            
        if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || !StringUtil.IsDigitsOnly(cpf))
        {
            return new ValidationResult(GetErrorMessage(validationContext));
        }
            
        return ValidationResult.Success;
    }
    private string GetErrorMessage(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            return "Invalid CPF";
        }
        ErrorMessageTranslationService errorTranslation = validationContext.GetService(typeof(ErrorMessageTranslationService)) as ErrorMessageTranslationService;
        return errorTranslation.GetLocalizedError(ErrorMessage);
    }
}
Then the service can be created as:
csharp
public class ErrorMessageTranslationService
{
    private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
    public ErrorMessageTranslationService(IStringLocalizer<SharedResource> sharedLocalizer)
    {
        _sharedLocalizer = sharedLocalizer;
    }
    public string GetLocalizedError(string errorKey)
    {
        return _sharedLocalizer[errorKey];
    }
}
The service can be registered as a singleton, in the Startup class.
csharp
services.AddSingleton<ErrorMessageTranslationService>();
If these validation attributes need to be factored to another assembly, just create an interface for this translation service that can be referenced by all validation attributes you create.
