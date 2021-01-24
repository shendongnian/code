    public class Product : IPermissionProtected
    {
    	...
    	
    	public Product(..., string[] allowedGroups)
    	{
    		this.AllowedGroups = allowedGroups;
    	}
    	
    	public string[] AllowedGroups { get; private set;}
    }
    
