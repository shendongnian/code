    [TestMethod]
    public void FinallyHappensOnError()
    {
    	bool finallyActionHappened = false;
    	try
    	{
    		Observable
    		.Throw<Unit>(new DivideByZeroException())
    		.Finally(() => finallyActionHappened = true)
    		.Subscribe(
    			_ => {},
    			() => Assert.IsTrue(finallyActionHappened)
    		);
    	}
    	catch
    	{
    	}
    	
    }
