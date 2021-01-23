    public class Car : VBase
    {
    	public string Name
    	{
    		get;
    		set;
    	}
    
    	public int Year
    	{
    		get;
    		set;
    	}
    
    	public VBase Base
    	{
    		set
    		{
    			base.Type = value.Type;
    			base.Colour = value.Colour;
    		}
    	}
    }
