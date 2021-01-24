    public class SomeClass
    {
        [DataMember]
        public object Var1 {get; set; }
    
        [DataMember]
        public object Var2 {get; set; }
    
        [DataMember]
        public object Var3 {get; set; }
    	
    	public bool SerializeVar2 {get; set; }
    	
    	public bool ShouldSerializeVar2
    	{
    	    return SerializeVar2;
    	}
    }
