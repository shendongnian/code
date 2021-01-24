    public interface IService<T>
    	{
    		
    	}
    
    	public interface IResolveService
    	{
    		IService<T> Resolve<T>();
    	}
    	
    	public class ResolveService : IResolveService
    	{
    		private readonly IServiceProvider _provider;
    
    		public ResolveService(IServiceProvider provider)
    		{
    			_provider = provider;
    		}
    
    		public IService<T> Resolve<T>()
    		{
    			//some logic here. May by resolving some instances using IServiceProvider
    			throw new NotImplementedException();
    		}
    	}
    
    	public class MyClass
    	{
    		public MyClass(IResolveService resolveService)
    		{
    			Service = resolveService.Resolve<int>();
    		}
    
    		private IService<int> Service { get; }
    	}
