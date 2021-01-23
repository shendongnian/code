    class Program
    {
    	static void Main(string[] args)
    	{
    		try
    		{
    			Alpha();
    
    		}
    		catch (Exception e) // don't try this at home kids
    		{
    			// we should never get here in this example
    			throw;
    		}
    
    	}
    
    	private static void Alpha()
    	{
    		try
    		{
    			Bravo();
    		}
    		catch (Exception e)
    		{
    			// debugger won't stop here because we didn't re-throw
    		}
    	}
    
    	private static void Bravo()
    	{
    		try
    		{
    			Tango();
    		}
    		catch (Exception)  // don't try this at home kids
    		{
    			throw;  // debugger will stop here again because we are re-throwing
    		}
    	}
    
    	private static void Tango()
    	{
    		var x = 1;
    		var y = 0;
    		var c = x / y;
    	}
    }
