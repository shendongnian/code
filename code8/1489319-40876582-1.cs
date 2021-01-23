    public class LogExceptionsAttribute : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            // Create a log message, you can access the method info and parameters
        }
    }
