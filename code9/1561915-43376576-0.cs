    public class POC
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    
    	public POC(int id, string name)
    	{
    	  Id = id;
    	  Name = name;
    	}
    }
    
    public class ChildPOC
    {
    	public int ParentId { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    
    	public ChildPOC(int parentId, string firstName, string lastName)
    	{
    	  ParentId = parentId;
    	  FirstName = firstName;
    	  LastName = lastName;
    	}
    }
    public class ChildPOCAlter
    {
    	public int ParentId { get; set; }
    	public string Name { get; set; }
    
    	public ChildPOCAlter(string first, string last, int parentId)
    	{
    	  ParentId = parentId;
    	  Name = $"{first} {last}";
    	}
    }
