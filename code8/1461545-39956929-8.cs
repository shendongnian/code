    [HandleProcessCorruptedStateExceptions, SecurityCritical]
    static void Main(string[] args)
    {
        try
        {
        	...
        }
        catch (Exception ex)
        {
        	// Log the CSE.
        }
    }
