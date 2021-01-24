    public class MyObject :ICloneable
    {
    	public List<AnotherObject> MyProperty { get; set; }
    	
    	public object Clone()
    	{
    		return this.MemberwiseClone();
    	}
    }
