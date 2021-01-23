    public class Hierarchy
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public Hierarchy Parent { get; set; }
    	public ICollection<Hierarchy> Children { get; set; }
    }
