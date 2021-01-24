    public class UserValidatorDecorator<TUser> : IUserValidator<TUser> where TUser : ApplicationUser
    {
        // Default UserValidator
        private readonly UserValidator<TUser> _userValidator;
        // Some class with additional options
        private readonly AdditionalOptions _additionalOptions;
        // You can use default error describer or create your own
        private readonly IdentityErrorDescriber _errorDescriber;
        public UserValidatorDecorator(UserValidator<TUser> userValidator,
                                      AdditionalOptions additionalOptions,
                                      IdentityErrorDescriber errorDescriber)
        {
            _userValidator = userValidator;
            _additionalOptions = additionalOptions;
            _errorDescriber = errorDescriber;
        }
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager,
                                                        TUser user)
        {
            // call to default validator
            var identityResult = await _userValidator.ValidateAsync(manager, user);
            // if default validation is already failed you can just return result, otherwise call  
            // your additional validation method
            return identityResult.Succeeded ? 
                AdditionalValidation(user) :
                identityResult;
        }
        public IdentityResult AdditionalUserNameValidation(TUser user)
        {
            // now you can check any value, if you need you can pass to method 
            // UserManager as well
            var someValue = user.SomeValue;
            if (someValue < _additionalOptions.MaximumValue)
            {
                return IdentityResult.Failed(_errorDescriber.SomeError(userName));
            }
            return IdentityResult.Success;
        }
    }
