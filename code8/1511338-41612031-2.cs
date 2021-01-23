    public class BaseEntity
    {
	    public int Id { get; set;}
    }
    public class Product : BaseEntity
    {
	    public string Name { get; set; }
    	public string Category { get; set; }
    }
