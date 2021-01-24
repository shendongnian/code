    public class ErrorMessageInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                // log your exception
                invocation.ReturnValue = "Your specific error message.";
            }
        }
    }
