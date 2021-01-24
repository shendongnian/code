    public class A
    {
    	public int one { get; set; }
    	public int two { get; set; }
    
    	public static implicit operator A(B v)
    	{
    		return new A
    		{
    			one = v.one,
    			two = v.two
    		};
    	}
    }
