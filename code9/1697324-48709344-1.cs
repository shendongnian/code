    public abstract class BaseType
    {
        public abstract void Execute();
    }
    public class VhdType : BaseType
    {
        public override void Execute()
        {
            Console.WriteLine("Vhd");
        }
    }
    public class XyzType : BaseType
    {
    	public override void Execute()
    	{
    		Console.WriteLine("Xyz");
    	}
    }
    public interface IRequestProcessor
    {
    	BaseType Process();
    }
    
    public interface IRequestProcessor<T> : IRequestProcessor where T : BaseType, new()
    {
    	T Process<TInput>() where TInput : T;
    }
    
    public class VhdRequestProcessor : IRequestProcessor<VhdType>
    {
    	public BaseType Process()
    	{
    		return Process<VhdType>();
    	}
    
    	public VhdType Process<TInput>() where TInput : VhdType
    	{
    		return new VhdType();
    	}
    }
    
    public class XyzRequestProcessor : IRequestProcessor<XyzType>
    {
    	public BaseType Process()
    	{
    		return Process<XyzType>();
    	}
    
    	public XyzType Process<TInput>() where TInput : XyzType
    	{
    		return new XyzType();
    	}
    }
    
    public class RequestFactory
    {
    	public IRequestProcessor GetRequest(string requestType)
    	{
    		switch (requestType)
    		{
    			case "vhd": return new VhdRequestProcessor();
    			case "xyz": return new XyzRequestProcessor();
    		}
    
    		throw new Exception("Invalid request");
    	}            
    }
