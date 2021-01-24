    public async Task FinallyHappensOnError()
    {
    	bool finallyActionHappened = false;
    	try
    	{
    		await Observable.Throw<Unit>(new DivideByZeroException())
    			.Finally(() => finallyActionHappened = true);
    	}
    	catch
    	{
    	}
    	Assert.IsTrue(finallyActionHappened);
    
    }
