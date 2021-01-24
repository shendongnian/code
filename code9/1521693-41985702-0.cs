    public class MyClass : MyBaseClass
    {
    	private readonly string _a;
    
    	public MyClass(string a)
    	{
    		_a = a;
    	}
    
    	public override string ToMyString()
    	{
    		var test = new MyNewClass(_a);
    		return test.MyValue();
    	}
    }
    
    class MyNewClass
    {
    	private readonly string _a;
    
    	public MyNewClass(string _a)
    	{
    		this._a = _a;
    	}
    
    	public string MyValue() { return _a; }
    }
