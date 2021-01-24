    public async Task<bool> LoginAsync(string username, string password)
    {
    	var tcs = new TaskCompletionSource<object>();
    	ICallBack callback = new CallBackAsync(tcs);
    	userService.Authenticate(username, password, callback);
    	var result = await tcs.Task;
    	return result is User ? true : false;
    }
    
    public class CallBackAsync : ICallBack
    {
    	private TaskCompletionSource<object> _tcs;
    	public CallBackAsync(TaskCompletionSource<object> tcs)
    	{
    		_tcs = tcs;
    	}
    	
    	public void OnSuccess(object response)
    	{
    		_tcs.TrySetResult(response);
    	}
    	public void OnException(Exception ex) {
    		_tcs.TrySetException(ex);
    	}
    }
