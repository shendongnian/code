    private void TimerEvent(object x)
    {
    	try
    	{
    		throw new Exception("Exception in timer event");
    	}
    	catch (Exception ex)
    	{
            Code.Helpers.Error.Functions.RecordError(ex);
    	}
    }
