    public class A
    {
    	public int Id { get; set; }
    	public string Description { get; set; }
    	
    	public virtual ICollection<B> Children { get; set; }
    }
    
    public class B
    {
    	public int Id { get; set; }
    	public string Description { get; set; }
    	
    	public int ParentId { get; set; }
    	public virtual A Parent { get; set; }
    }
