    public class ApiException
    {
    	public static Task<Exception> CreateFromHttpMessage(HttpResponseMessage message)
    	{
    		return Task.FromResult(new Exception());
    	}
    }
