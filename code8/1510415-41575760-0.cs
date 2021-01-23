    void Main()
    {
    	var i = new B();
    	i.Time.Dump();
    }
    
    // Define other methods and classes here
    public class A
    {
    	public A()
    	{
    		Time = DateTime.Now;
    	}
    	public DateTime Time {get;set;}
    }
    
    public class B : A
    {
    	public B() : base()
    	{
    	
    	}
    }
