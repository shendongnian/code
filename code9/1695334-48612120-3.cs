    interface IService<T1, T2>
    {
    	T1 GetValue();
    	T2 GetAnotherValue();
    }
    class MyClass : IService<string, int>
    {
    	public int GetAnotherValue()
    	{
    		return 42;
    	}
    
    	public string GetValue()
    	{
    		return "Truth";
    	}
    }
