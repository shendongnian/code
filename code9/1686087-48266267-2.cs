    public void Intercept(IInvocation invocation)
    {
        if (invocation.MethodInvocationTarget.Name != nameof(ISomeService.Create))
        {
            invocation.Proceed();
            return;
        }
        using (var transaction = ...)
        {
            try
            {
                invocation.Proceed();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
