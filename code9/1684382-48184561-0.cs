    Class1 A = new Class1();
     
    Task<AuthenticationResult> authenticationTask = DoSomething();
    // Register an Action<Task<T>> to run when the task has transitioned RanToCompletion 
    // or Faulted
    authenticationTask.ContinueWith(p =>
    {
        if(p.IsFaulted) // Handle any exceptions!
        {
            Exception ex = p.Exception
        }
        else
        {
            // Success! :D Process the result as usual.
            // Task<T>.Result is an instance of T - in our case, AuthenticationResult. 
            // It would be default(T) if a task has faulted or has not completed. 
            // At this point, we are confident that the task has completed without a fault.
            A.Method1(p.Result);
        }
    });
