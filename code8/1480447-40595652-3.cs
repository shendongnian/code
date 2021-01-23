    [ModulePrefix("A"), TablePrefix("PAR")]
    public class Parent
    {
    	public Guid Id { get; set; }
    	public string Data { get; set; }
    }
    
    [ModulePrefix("B"), TablePrefix("CHL")]
    public class Child : Parent
    {
    	public string ChildData { get; set; }
    }
