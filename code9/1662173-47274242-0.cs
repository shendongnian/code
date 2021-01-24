    [JsonProperty("list")]
    public class WrapperClass {
    	public ClassA ClassA{get; set;}
    	public ClassB ClassB{get; set;}
    }
    
    public class ClassA:IInterface{
       public String PropertyA{get; set;}
    }
    public class ClassB:IInterface{
       public String PropertyB{get; set;}
    }
