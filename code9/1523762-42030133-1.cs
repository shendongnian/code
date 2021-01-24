    using FluentValidation;
    using FluentValidation.Results;
    
    namespace Business.Managers.Interfaces
    {
        public class ValidationManager : IValidationManager
        {
            private readonly IValidatorFactory _validatorFactory;
    
            public ValidationManager(IValidatorFactory validatorFactory)
            {
                _validatorFactory = validatorFactory;
            }
    
            public ValidationResult Validate<T>(T entity) where T : class
            {
                var validator = _validatorFactory.GetValidator(entity.GetType());
                var result = validator.Validate(entity);
                return result;
            }
        }
    }
