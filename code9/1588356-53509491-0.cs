    public interface IServiceLocator : IDisposable
    {
    	T Get<T>();
    }
    
    public class ScopedServiceLocator : IServiceLocator
    {
    	private readonly IServiceScopeFactory _factory;
    	private IServiceScope _scope;
    
    	public ScopedServiceLocator(IServiceScopeFactory factory)
    	{
    		_factory = factory;
    	}
    
    	public T Get<T>()
    	{
    		if (_scope == null)
    			_scope = _factory.CreateScope();
    
    		return _scope.ServiceProvider.GetService<T>();
    	}
    
    
    	public void Dispose()
    	{
    		_scope?.Dispose();
    		_scope = null;
    	}
    }
