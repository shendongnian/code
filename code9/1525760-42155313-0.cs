    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            logWriter.Debug("Validating resource owner password: " + context.UserName);
            if (_userRepository.ValidatePassword(context.UserName, context.Password))
            {
                context.Result = new GrantValidationResult(context.UserName, "password");
                return Task.FromResult(0);
            }
    
            logWriter.Debug("Unauthorised resource owner password for: " + context.UserName);
            return Task.FromResult(new GrantValidationResult(TokenRequestErrors.UnauthorizedClient));
        }
