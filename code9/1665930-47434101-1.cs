    try
    {
    	var currentImageCounter = Interlocked.Increment(ref imageCounter);
    	if (currentImageCounter > 3)
    	{
    		throw new Exception(""); //Should be caught and result in HttpResponse.Status = 429
    	}
    	
    	//Image processing code here
    	
    }
    finally
    {
    	Interlocked.Decrement(ref ImageCounter);
    }
