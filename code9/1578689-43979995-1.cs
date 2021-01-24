    public async Task OnActionExecutionAsync(ActionExecutingContext context, 
                                             ActionExecutionDelegate next)
    {
        // logic before action goes here
        await next(); // the actual action
        // logic after the action goes here
    }
