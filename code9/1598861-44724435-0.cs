    public class BaseClass
    {
        public string Field1 { get; set; }
    	
    	public BaseClass(){	}
    	public BaseClass(DerivedClass dc)
    	{
    		this.Field1 = dc.Field1;
    	}
    }
    
    public class DerivedClass : BaseClass
    {
    	public string Field2 { get; set; }
    }
