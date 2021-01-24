    public interface IFooType
    { }
    
    public interface IFooType1 : IFooType
    { }
    
    public interface IFooType2 : IFooType
    { }
    
    public interface IFoo<T>
    	where T : IFooType
    {
    	string FooType { get; }
    }
    
    public class Foo<T> : IFoo<T>
    	where T : IFooType
    {
    	public string FooType
    	{
    		get
    		{
    			return typeof(T).ToString();
    		}
    	}
    }
