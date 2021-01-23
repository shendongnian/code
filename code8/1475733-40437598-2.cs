    public class ModelValidator : IModelValidator
    {
        public List<ValidationErrorModel> Validate<T>(T model) 
        {
            // provider is a IServiceProvider
            var validator = provider.RequireService(typeof(IValidator<T>));
            return validator.Validate(model);
        }
    }
