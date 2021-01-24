    public void Intercept(IInvocation invocation)
    {
        if (invocation.Method.Name != nameof(ISomeService.Create))
        {
            invocation.Proceed();
            return;
        }
        // begin transaction, try/catch, etc. 
    }
