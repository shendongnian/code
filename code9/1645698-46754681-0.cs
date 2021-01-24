    public class Test
    {
        public Test()
    	{
    	   isConnected =new Task<bool>(()=> {return true;});
    	}
    	
        public string Foo{get;set;}
    
    	private Task<bool> isConnected;
    	
    	[JsonIgnore] // do not serialize
    	public Task<bool> IsConnected
    	{    	
    		get { return isConnected; }
    		set { isConnected = value; }
    	} 
    }
