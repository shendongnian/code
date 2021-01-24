    public class MyTuple<TypeParameter1, TypeParameter2>
    {
    	public TypeParameter1 Value1 { get; set; }
    	public TypeParameter2 Value2 { get; set; }
    
    	public MyTuple()
    	{
    		
    	}
    	public MyTuple(TypeParameter1 value1, TypeParameter2 value2)
    	{
    		Value2 = value2;
    		Value1 = value1;
    	}
    }
