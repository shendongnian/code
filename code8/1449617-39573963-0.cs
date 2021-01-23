    [IntroduceInterface( typeof(IGenericInterface) )]
    public class DynamicInterfaceAspect : InstanceLevelAspect, IGenericInterface
    {
    	readonly Type parameterType;
    
    	public DynamicInterfaceAspect( Type parameterType )
    	{
    		this.parameterType = parameterType;
    	}
    
    	public override void RuntimeInitializeInstance()
    	{
    		var type = typeof(GenericInterfaceAdapter<>).MakeGenericType( parameterType );
    		Inner = (IGenericInterface)Activator.CreateInstance( type, Instance );
    	}
    
    	IGenericInterface Inner { get; set; }
    	public void HelloWorld( object parameter ) => Inner.HelloWorld( parameter );
    }
    
    public interface IGenericInterface
    {
    	void HelloWorld( object parameter );
    }
    
    public class GenericInterfaceAdapter<T> : IGenericInterface
    {
    	readonly IGenericInterface<T> inner;
    
    	public GenericInterfaceAdapter( IGenericInterface<T> inner )
    	{
    		this.inner = inner;
    	}
    
    	public void HelloWorld( object parameter ) => inner.HelloWorld( (T)parameter );
    }
    
    public interface IGenericInterface<in T>
    {
    	void HelloWorld( T parameter );
    }
