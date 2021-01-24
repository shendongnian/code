    public class Product
    {
    	#region Variables
    	private string _Name = string.Empty;
    	private string _Category = string.Empty;
    	private List<ProductSetting> _Settings = new List<ProductSetting>();
    	#endregion Variables
    
    	#region Properties
    	public string Name
    	{
    		get
    		{
    			return this._Name;
    		}
    		set
    		{
    			this._Name = value;
    		}
    	}
    
    	public string Category
    	{
    		get
    		{
    			return this._Category;
    		}
    		set
    		{
    			this._Category = value;
    		}
    	}
    
    	public List<ProductSetting> Settings
    	{
    		get
    		{
    			return this._Settings;
    		}
    		set
    		{
    			this._Settings = value;
    		}
    	}
    	#endregion Properties
    
    	#region Constructors
    	public Product()
    	{
    	}
    
    	public Product(string name, string category, List<ProductSetting> settings)
    	{
    		this.Name = name;
    		this.Category = category;
    		this.Settings = settings;
    	}
    	#endregion Constructors
    }
