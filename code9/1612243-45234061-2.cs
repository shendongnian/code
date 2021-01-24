    public class BaseType
    {
    	public int SharedProp { get; set; } // shared property 
    	
    	public virtual int DoSharedStuff() // shared method
    	{
    		return SharedProp;
    	}    
    }
    
    public class myTypeA : BaseType
    {
    	public int A_Prop { get; set; }
    	
        // overwritten shared meth adjusted to the needs of type A
    	public override int DoSharedStuff() 
    	{
    		return base.SharedProp + this.A_Prop;
    	}
    }
    
    public class myTypeB : BaseType
    {
    	public int B_Prop { get; set; }
    
        // overwritten shared meth adjusted to the needs of type B
    	public override int DoSharedStuff()
    	{
    		return base.SharedProp + this.B_Prop;
    	}
    
        // individual method of Type B
    	public int DoB_Stuff()
    	{
    		return this.B_Prop;
    	}
    }
