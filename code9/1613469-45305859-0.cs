    public class DisposableAsync
    {
    	private readonly IDisposable _disposable; 
    	private readonly Func<Task> _asyncDisposalAction;
    	public DisposableAsync(IDisposable disposable, Func<Task> asyncDisposalAction)
    	{
    		_disposable = disposable;
    		_asyncDisposalAction = asyncDisposalAction;
    	}
    	
    	public Task DisposeAsync()
    	{
    		_disposable.Dispose();
    		return _asyncDisposalAction();
    	}
    }
    
    public static class DisposableAsyncExtensions
    {
    	public static DisposableAsync ToAsync(this IDisposable disposable, Func<Task> asyncDisposalAction)
    	{
    		return new DisposableAsync(disposable, asyncDisposalAction);
    	}
    }
