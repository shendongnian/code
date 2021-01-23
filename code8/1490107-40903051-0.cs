    void Main()
    {
    	var foo = new Foo { Long = -1 };
    	
    	Console.WriteLine(foo.ULong);
    }
    
    // Define other methods and classes here
    [StructLayout(LayoutKind.Explicit)]
    public class Foo
    {
    	[FieldOffset(0)]
    	private ulong _ulong;
    	
    	[FieldOffset(0)]
    	private long _long;
    
    	public long Long
    	{
    		get { return _long; }
    		set { _long = value; }
    	}
    
    	public ulong ULong
    	{
    		get { return _ulong; }
    		set { _ulong = value; }
    	}
    }
