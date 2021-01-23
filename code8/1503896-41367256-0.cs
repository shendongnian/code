    PreRegistrationHandler = (context, cancellationToken) =>
    {
        var passesvalidation = DoesPassValidation(context); // evals to false
        if (!passesvalidation)
        {
            context.Result = new PreRegistrationResult()
            {
                Success = false,
                ErrorMessage = "No way, José!" // optional validation message
            };
            return Task.FromResult(1); // returned value doesn't matter
        }
        return Task.FromResult(0); // without setting context.Result, success is assumed
    }
