    public static T BlockWithoutLockup<T>(Func<Task<T>> task)
    {
        T result;
    
        if(SynchronizationContext.Current != null)
        {
            //We use ".GetAwaiter().GetResult()" instead of .Result to get the exception handling 
            // like we would if we had called `await` or the function directly.
            result = Task.Run(task).GetAwaiter().GetResult();
        }
        else
        {
            //If we are on the default sync context already just run the code, no need to
            // spin up another thread.
            result = task().GetAwaiter().GetResult();
        }
        return result;
    }
