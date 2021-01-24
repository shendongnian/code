    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();
        if (failures.Any())
        {
            var response = new Thing(); //obviously a type conforming to TResponse
            response.Failures = failures; //I'm making an assumption on the property name here.
            return Task.FromResult(response);
        }
        else
        {
            return next();
        }
    }
