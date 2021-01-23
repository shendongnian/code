    void Main()
    {
    	int value = GetValue(123);
    	DoSomething(value);
    }
    
    void DoSomething(int myParam)
    {
    	RunAndLogError(() => {
    		// Place code here
    		Console.WriteLine(myParam);
    		});
    }
    
    int GetValue(int myParam)
    {
    	return RunAndLogError(() => {
    		// Place code here
    		return myParam * 2;});
    }
    
    void RunAndLogError(Action act)
    {
    	try
    	{
    		act();
    	}
    	catch(Exception ex)
    	{
    		// Log error
    		throw;
    	}
    }
    
    T RunAndLogError<T>(Func<T> fct)
    {
    	try
    	{
    		return fct();
    	}
    	catch(Exception ex)
    	{
    		// Log error
    		throw;
    	}
    }
