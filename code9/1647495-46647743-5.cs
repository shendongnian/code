    abstract class MyAbstractClass
    {
    	public virtual object GetValue(object parameter)
    	{
    		Console.WriteLine("Hello from object");
    		return parameter;
    	}
    }
    
    abstract class MyAbstractClass<T> : MyAbstractClass
    {
    	override public object GetValue(object parameter)
    	{
    		return GetValue((T)parameter);
    	}
    
    	public T GetValue(T parameter)
    	{
    		Console.WriteLine("Hello from generics");
    		return parameter;
    	}
    }
    
    class MyImpClass : MyAbstractClass<string> { }
