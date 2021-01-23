    public interface IClassICFactory
    {
    	IC CreateInstance();
    }
    
    public class ClassICUnityContainerFactory : IClassCFactory
    {
    	private IUnityContainer _container;
    
    	public ClassICUnityContainerFactory(IUnityContainer container)
    	{
    		_container = container;
    	}
    
    	public IC CreateInstance()
    	{
    		return _container.Resolve<C>();
    	}
    }
    
    class A : IA
    {
    	public A(IB b, IClassICFactory factory)
    	{
    		for (int i = 0; i < 10; i++)
    		{
    			var c = factory.CreateInstance();
    		}
    	}
    }
