    Description: The application requested process termination through System.Environment.FailFast(string message).
    Message: An exception was not handled in an AsyncLocal<T> notification callback.
    Stack:
       at System.Environment.FailFast(System.String, System.Exception)
       at System.Threading.ExecutionContext.OnAsyncLocalContextChanged(System.Threading.ExecutionContext, System.Threading.ExecutionContext)
       at System.Threading.ExecutionContext.SetExecutionContext(System.Threading.ExecutionContext, Boolean)
       at System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
       at System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
       at System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)
       at System.Threading.ThreadHelper.ThreadStart(System.Object)
