    [DataContract] // serialize this class
    public class Test2
    {
    
        public Test2(){
    	   isConnected =new Task<bool>(()=> {return true;});
    	}
    	
    	[DataMember] // serialize this property
        public string Foo{get;set;}
    
    	private Task<bool> isConnected;
    	// no DataMember so this one isn't serialized 
    	public Task<bool> IsConnected
    	{
    		get { return isConnected; }
    		set { isConnected = value; }
    	} 
    }
