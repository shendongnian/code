    public class ProductSetting
    {
    	#region Variables
    	private string _Setting1 = string.Empty;
    	private string _Setting2 = string.Empty;
    	//...
    	#endregion Variables
    	
    	#region Properties
    	public string Setting1
    	{
    		get
    		{
    			return this._Setting1;
    		}
    		set
    		{
    			this._Setting1 = value;
    		}
    	}
    
    	public string Setting2
    	{
    		get
    		{
    			return this._Setting2;
    		}
    		set
    		{
    			this._Setting2 = value;
    		}
    	}
    	#endregion Properties
    	
    	#region Constructors
    	public ProductSetting()
    	{
    	}
    
    	public ProductSetting(string setting1, string setting2)
    	{
    		this.Setting1 = setting1;
    		this.Setting2 = setting2;
    	}
    	#endregion Constructors
    }
